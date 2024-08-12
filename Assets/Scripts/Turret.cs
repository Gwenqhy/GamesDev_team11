using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Camera _camera;
    [SerializeField, Range(1, 100)] private float rotationSpd = 1;
    // Start is called before the first frame update
    void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.up = Vector3.MoveTowards(transform.up, mousePos, rotationSpd * Time.deltaTime);
    }
}
