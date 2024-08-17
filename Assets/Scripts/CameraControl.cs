namespace DevelopersHub.DefendersKeep
{


    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraControl : MonoBehaviour
    {
        Vector3 MouseScrollStartingPosition;
        Camera gameCamera;
        int mapSize = 25;


        public float zoomingSpeed = 3f; //speed at which the camera zooms in and out
        public float minimumZoom = 1f;   // how much you can zoom in
        public float maximumZoom = 5f;  // how much you can zoom out

        // Start is called before the first frame update
        void Start()
        {
            gameCamera = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            ScrollButtonHandling();
            EdgeScrollhandling();
            Zooming();
        }

        private void ScrollButtonHandling()
        {
            if (Input.GetMouseButtonDown(2))
            {
                MouseScrollStartingPosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(2))
            {
                Vector3 movement = Vector3.zero;
                movement = gameCamera.ScreenToWorldPoint(Input.mousePosition) - MouseScrollStartingPosition;
                gameCamera.transform.position -= movement;
            }
        }

        private void EdgeScrollhandling()
        {
            int distTop = gameCamera.pixelHeight - (int)Input.mousePosition.y;
            int distBtm = (int)Input.mousePosition.y;
            int distRight = gameCamera.pixelWidth - (int)Input.mousePosition.x;
            int distLeft = (int)Input.mousePosition.x;
            if (distTop < mapSize && distTop > 0)
            {
                gameCamera.transform.position += Vector3.up * Time.deltaTime;
            }
            else if (distBtm < mapSize && distBtm > 0)
            {
                gameCamera.transform.position += Vector3.down * Time.deltaTime;
            }
            if (distLeft < mapSize && distLeft > 0)
            {
                gameCamera.transform.position += Vector3.left * Time.deltaTime;
            }
            else if (distRight < mapSize && distRight > 0)
            {
                gameCamera.transform.position += Vector3.right * Time.deltaTime;
            }
        }

        private void Zooming()
        {
            float scrollValue = Input.GetAxis("Mouse ScrollWheel");
            if (scrollValue != 0f)
            {
                gameCamera.orthographicSize -= scrollValue * zoomingSpeed;
                gameCamera.orthographicSize = Mathf.Clamp(gameCamera.orthographicSize, minimumZoom, maximumZoom);
            }
        }
    }

}