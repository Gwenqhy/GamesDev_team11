using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Camera _camera;
    [SerializeField, Range(1, 100)] private float rotationSpd = 1;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firept;
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

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(projectilePrefab, firept.position, Quaternion.identity).Init(transform.up); 
        }
    }
}
