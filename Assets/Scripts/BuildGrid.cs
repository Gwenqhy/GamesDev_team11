/*This script is responsible for managing the grid system in which objects can be 
snapped to structured grid cells. It includes methods to check, occupy, or vacate 
grid cells and can show or hide the grid lines in white,  color-coded cells 
indicating occupied (red) or available (green) status.*/


namespace DevelopersHub.DefendersKeep
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BuildGrid : MonoBehaviour
    {
        // no. of rows and columns in the grid, and the size of each cell
        [SerializeField] private int _rows = 25;
        [SerializeField] private int _columns = 25;
        [SerializeField] private float _cellSize = 2f;

        // to keep track of which grid cells are occupied
        private HashSet<Vector3> occupiedCells = new HashSet<Vector3>();
        
        // Boolean to control visibility of grid
        private bool _showGrid = false;

        // allow other scripts to access the size of grid cell
        public float CellSize
        {
            get { return _cellSize; }
        }

        // check if a specific grid cell is already occupied, we want to snap the position to grid coordinates
        public bool IsCellOccupied(Vector3 gridPosition)
        {
            Vector3 snappedPosition = SnapToGrid(gridPosition); 
            return occupiedCells.Contains(snappedPosition); // check if the cell is occupied
        }

        // method to mark a grid cell as occupied
        public void OccupyCell(Vector3 gridPosition)
        {
            Vector3 snappedPosition = SnapToGrid(gridPosition); 
            if (!occupiedCells.Contains(snappedPosition)) // Only occupy if it's not already occupied
            {
                occupiedCells.Add(snappedPosition); // add the cell to the occupied set
                Debug.Log($"Cell occupied at position: {snappedPosition}"); // for debugging

                // Force the Scene view to update in the Unity Editor
                #if UNITY_EDITOR
                UnityEditor.SceneView.RepaintAll(); 
                #endif
            }
        }

        // Method to mark a grid cell as available (vacant)
        public void VacateCell(Vector3 gridPosition)
        {
            Vector3 snappedPosition = SnapToGrid(gridPosition); 
            if (occupiedCells.Contains(snappedPosition)) // Only vacate if the cell is currently occupied
            {
                occupiedCells.Remove(snappedPosition); // Remove the cell from the occupied set
                Debug.Log($"Cell vacated at position: {snappedPosition}"); // for debugging

                // Force the Scene view to update in the Unity Editor
                #if UNITY_EDITOR
                UnityEditor.SceneView.RepaintAll(); 
                #endif
            }
        }

        // Method to snap any position to the nearest grid cell based on the cell size
        private Vector3 SnapToGrid(Vector3 originalPosition)
        {
            float x = Mathf.Round(originalPosition.x / _cellSize) * _cellSize; // Round to nearest grid point in x direction
            float y = Mathf.Round(originalPosition.y / _cellSize) * _cellSize; // Round to nearest grid point in y direction
            return new Vector3(x, y, originalPosition.z); // Return snapped position
        }

        // Method to enable grid visibility
        public void ShowGrid()
        {
            _showGrid = true;
        }

        // Method to disable grid visibility
        public void HideGrid()
        {
            _showGrid = false;
        }

        #if UNITY_EDITOR
        // Draws the grid in the Unity Editor when the object is selected
        private void OnDrawGizmosSelected()
        {
            if (!_showGrid) return; // If _showGrid is false, do not draw the grid

            // Draw the grid lines in white color
            Gizmos.color = Color.white;
            for (int i = 0; i <= _rows; i++)
            {
                Vector3 point = transform.position + Vector3.up * _cellSize * i; // Calculate grid line position
                Gizmos.DrawLine(point, point + Vector3.right * _cellSize * _columns); // Draw horizontal line
            }
            for (int i = 0; i <= _columns; i++)
            {
                Vector3 point = transform.position + Vector3.right * _cellSize * i; // Calculate grid line position
                Gizmos.DrawLine(point, point + Vector3.up * _cellSize * _rows); // Draw vertical line
            }

            // Highlight each grid cell based on whether it is occupied or available
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Vector3 gridPosition = transform.position + new Vector3(_cellSize * j, _cellSize * i, 0); 
                    Vector3 cellCenter = gridPosition + new Vector3(_cellSize / 2, _cellSize / 2, 0); 

                    // Set the color based on whether the cell is occupied
                    if (IsCellOccupied(gridPosition))
                    {
                        Gizmos.color = new Color(1f, 0f, 0f, 0.5f); // Red color for occupied cells
                    }
                    else
                    {
                        Gizmos.color = new Color(0f, 1f, 0f, 0.5f); // Green color for available cells
                    }

                    Gizmos.DrawCube(cellCenter, new Vector3(_cellSize, _cellSize, 0.1f)); // Draw a colored cube to represent the grid cell
                }
            }
        }
        #endif
    }
}
