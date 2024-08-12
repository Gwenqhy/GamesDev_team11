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

            transform.up = Vector3.MoveTowards(transform.up, mousePos, rotationSpd * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectilePrefab, firept.position, Quaternion.identity).Init(transform.up);
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
