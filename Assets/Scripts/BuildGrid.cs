
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
        private bool _showGrid = false; // Control grid visibility

        private HashSet<Vector3> occupiedCells = new HashSet<Vector3>();

        // Property to access cell size from other scripts
        public float CellSize
        {
            get { return _cellSize; }
        }

        void Start()
        {
            _showGrid = false; // Ensure the grid is hidden by default
        }

        // Method to show the grid
        public void ShowGrid()
        {
            _showGrid = true;
        }

        // Method to hide the grid
        public void HideGrid()
        {
            _showGrid = false;
        }

        public bool IsCellOccupied(Vector3 gridPosition)
        {
            return occupiedCells.Contains(gridPosition);
        }

        public void OccupyCell(Vector3 gridPosition)
        {
            occupiedCells.Add(gridPosition);
        }

        public void VacateCell(Vector3 gridPosition)
        {
            occupiedCells.Remove(gridPosition);
        }

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!_showGrid) return; // Only draw grid if _showGrid is true

            // Draw the grid lines
            Gizmos.color = Color.white;
            for (int i = 0; i <= _rows; i++)
            {
                Vector3 point = transform.position + transform.forward.normalized * _cellSize * (float)i;
                Gizmos.DrawLine(point, point + transform.right.normalized * _cellSize * (float)_columns);
            }
            for (int i = 0; i <= _columns; i++)
            {
                Vector3 point = transform.position + transform.right.normalized * _cellSize * (float)i;
                Gizmos.DrawLine(point, point + transform.forward.normalized * _cellSize * (float)_rows);
            }

            // Highlight occupied and available grid cells
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Vector3 gridPosition = transform.position + new Vector3(_cellSize * j, _cellSize * i, 0);
                    Vector3 cellCenter = gridPosition + new Vector3(_cellSize / 2, _cellSize / 2, 0); // Center the color

                    if (occupiedCells.Contains(gridPosition))
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







