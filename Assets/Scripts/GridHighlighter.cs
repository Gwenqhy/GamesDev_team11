using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GridHighlighter : MonoBehaviour
{
    public GridLayoutGroup gridLayout;  // Reference to the Grid Layout
    public Color highlightColor = Color.yellow;  // The color to use for highlighting
    public Color defaultColor = Color.white;  // The default color for the grid squares

    private Image[] gridSquares;  // Array to hold references to all grid squares
    private Image highlightedSquare;  // Reference to the currently highlighted square

    void Start()
    {
        // Get references to all the grid squares (children of the GridPanel)
        gridSquares = gridLayout.GetComponentsInChildren<Image>();
    }

    void Update()
    {
        // Get the cursor position in screen space
        Vector2 cursorPosition = Input.mousePosition;

        // Check each grid square to see if the cursor is over it
        foreach (Image square in gridSquares)
        {
            RectTransform rectTransform = square.GetComponent<RectTransform>();

            // Check if the cursor is within the bounds of this square
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, cursorPosition, Camera.main))
            {
                // If the square isn't already highlighted, highlight it
                if (highlightedSquare != square)
                {
                    HighlightSquare(square);
                }
                return;  // Exit the loop once the correct square is found
            }
        }

        // If no square is under the cursor, reset the highlighted square
        if (highlightedSquare != null)
        {
            ResetHighlight();
        }
    }

    void HighlightSquare(Image square)
    {
        // Reset the previous square color
        if (highlightedSquare != null)
        {
            highlightedSquare.color = defaultColor;
        }

        // Highlight the new square
        highlightedSquare = square;
        highlightedSquare.color = highlightColor;
    }

    void ResetHighlight()
    {
        highlightedSquare.color = defaultColor;
        highlightedSquare = null;
    }
}
