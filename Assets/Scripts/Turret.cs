using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Camera _camera;
    [SerializeField, Range(1, 100)] private float rotationSpd = 1;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firept;
    private bool isSelected = false;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    [SerializeField] private Color selectedColor = Color.red;
    [SerializeField] private float rateOfFire = 0.5f; 
    private float lastFiredTime = 0f;
    void Awake()
    {
        _camera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        HandleSelection();
        if (isSelected)
        {
            var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3 direction = (mousePos - transform.position).normalized;

            // Calculate the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpd * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space) && Time.time - lastFiredTime >= rateOfFire)
            {
                Instantiate(projectilePrefab, firept.position, Quaternion.identity).Init(transform.up);

                lastFiredTime = Time.time;

            }
        }
        


    }

    private void HandleSelection()
    {
 
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null && collider.OverlapPoint(mousePos))
            {
                isSelected = true;
                spriteRenderer.color = selectedColor;
            }
            else
            {
                isSelected = false;
                spriteRenderer.color = originalColor;
            }
        }
    }
}
