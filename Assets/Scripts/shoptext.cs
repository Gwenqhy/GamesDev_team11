using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shoptext : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject textBox; // Assign your Text or TextMeshPro GameObject here
    public Vector2 offset = new Vector2(0, 50f); // Offset above the mouse position

    // Start is called before the first frame update
    void Start()
    {
        if (textBox != null)
        {
            textBox.SetActive(false); // Ensure the text box is hidden initially
        }
    }

    // This method is called when the pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textBox != null)
        {
            textBox.SetActive(true); // Show the text box
            UpdateTextBoxPosition();
        }
    }

    // This method is called when the pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        if (textBox != null)
        {
            textBox.SetActive(false); // Hide the text box
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (textBox != null && textBox.activeSelf)
        {
            UpdateTextBoxPosition(); // Continuously update position while active
        }
    }

    void UpdateTextBoxPosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        textBox.transform.position = mousePosition + offset; // Set text box position with offset
    }
}
