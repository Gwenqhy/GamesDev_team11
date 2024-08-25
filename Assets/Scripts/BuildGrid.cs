namespace DevelopersHub.DefendersKeep
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BuildGrid : MonoBehaviour
    {
        [SerializeField] private int _rows = 45;
        [SerializeField] private int _columns = 45;
        [SerializeField] private float _cellSize = 2f;  // Now adjustable from the Inspector

        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
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
        }
        #endif

		public float CellSize
        {
            get { return _cellSize; }
        }
    }

}