


namespace DevelopersHub.DefendersKeep
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BuildGrid : MonoBehaviour
    {
        [SerializeField] private int _rows = 25;
        [SerializeField] private int _columns = 25;
        [SerializeField] private float _cellSize = 2f;

        private HashSet<Vector3> occupiedCells = new HashSet<Vector3>();
        private bool _showGrid = false;  // Control whether the grid is shown

        // Property to access cell size from other scripts
        public float CellSize
        {
            get { return _cellSize; }
        }

        public bool IsCellOccupied(Vector3 gridPosition)
        {
            Vector3 snappedPosition = SnapToGrid(gridPosition);
            return occupiedCells.Contains(snappedPosition);
        }

        public void OccupyCell(Vector3 gridPosition)
        {
            Vector3 snappedPosition = SnapToGrid(gridPosition);
            if (!occupiedCells.Contains(snappedPosition))
            {
                occupiedCells.Add(snappedPosition);
                Debug.Log($"Cell occupied at position: {snappedPosition}");

                // Refresh the gizmos to reflect the new occupied cell
                #if UNITY_EDITOR
                UnityEditor.SceneView.RepaintAll(); // Force scene view to repaint
                #endif
            }
        }

        public void VacateCell(Vector3 gridPosition)
        {
            Vector3 snappedPosition = SnapToGrid(gridPosition);

            if (occupiedCells.Contains(snappedPosition))
            {
                occupiedCells.Remove(snappedPosition);
                Debug.Log($"Cell vacated at position: {snappedPosition}");

                // Refresh the gizmos to reflect the vacated cell
                #if UNITY_EDITOR
                UnityEditor.SceneView.RepaintAll(); // Force scene view to repaint
                #endif
            }
        }

        private Vector3 SnapToGrid(Vector3 originalPosition)
        {
            // Snap the position to the nearest grid point
            float x = Mathf.Round(originalPosition.x / _cellSize) * _cellSize;
            float y = Mathf.Round(originalPosition.y / _cellSize) * _cellSize;
            return new Vector3(x, y, originalPosition.z);
        }

        public void ShowGrid()
        {
            _showGrid = true;
        }

        public void HideGrid()
        {
            _showGrid = false;
        }

        #if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (!_showGrid) return; // Only draw grid if _showGrid is true

            // Draw the grid lines
            Gizmos.color = Color.white;
            for (int i = 0; i <= _rows; i++)
            {
                Vector3 point = transform.position + Vector3.up * _cellSize * i;
                Gizmos.DrawLine(point, point + Vector3.right * _cellSize * _columns);
            }
            for (int i = 0; i <= _columns; i++)
            {
                Vector3 point = transform.position + Vector3.right * _cellSize * i;
                Gizmos.DrawLine(point, point + Vector3.up * _cellSize * _rows);
            }

            // Highlight occupied and available grid cells
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Vector3 gridPosition = transform.position + new Vector3(_cellSize * j, _cellSize * i, 0);
                    Vector3 cellCenter = gridPosition + new Vector3(_cellSize / 2, _cellSize / 2, 0); // Center the color

                    if (IsCellOccupied(gridPosition))
                    {
                        Gizmos.color = new Color(1f, 0f, 0f, 0.5f); // Highlight occupied grids with semi-transparent red
                    }
                    else
                    {
                        Gizmos.color = new Color(0f, 1f, 0f, 0.5f); // Highlight available grids with semi-transparent green
                    }

                    Gizmos.DrawCube(cellCenter, new Vector3(_cellSize, _cellSize, 0.1f));
                }
            }
        }
        #endif
    }
}

