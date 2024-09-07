/*This script handles the shop system for placing objects in a grid-based game. 
It manages the placement of objects, units, snapping them to grid cells, 
checking gold availability, and deducting gold upon placement. The script also 
supports cancelling placement and uses a visual grid to guide the placement process.*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DevelopersHub.DefendersKeep;

public class shop : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab of the object to be instantiated and placed
    public Button placeButton; // The button that initiates the placement process
    public Goldmanager goldManager; // Reference to the GoldManager script
    public GameObject textBox; // Reference to the TextBox to hide during placement

    public GameObject panel1; // Reference to Panel1 to hide during placement and show after placement
    public int goldCost = 20; // The gold cost to place the object, changeable in the Inspector

    private GameObject objectToPlace; // Reference to the currently placing object
    private bool isPlacing = false; // Tracks whether the object is currently being placed
    private BuildGrid buildGrid; // Reference to the grid for snapping
    private Collider2D objectCollider; // Reference to the object's collider (turret or other object)
    
    void Start()
    {
        // Add listener to the place button
        placeButton.onClick.AddListener(() => {
            if (goldManager.gold >= goldCost)  // Accessing the gold variable from the GoldManager script
            {
                BeginPlacement();
            }
            else
            {
                Debug.Log("Not enough gold to place the object!");
            }
        });
        
        // Find the BuildGrid component in the scene
        buildGrid = FindObjectOfType<BuildGrid>();
        if (buildGrid == null)
        {
            Debug.LogError("BuildGrid component not found in the scene!");
        }
    }

    void Update()
    {
        if (isPlacing && objectToPlace != null)
        {
            FollowCursor();

            // Left-click to place the object
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 snappedPosition = objectToPlace.transform.position;
                if (!buildGrid.IsCellOccupied(snappedPosition))
                {
                    PlaceObject(snappedPosition);
                }
                else
                {
                    Debug.Log("Grid cell is already occupied!");
                }
            }

            // Right-click to cancel placement
            if (Input.GetMouseButtonDown(1))
            {
                CancelPlacement();
            }
        }
    }

    void BeginPlacement()
    {
        // Hide Panel1
        panel1.SetActive(false);
        if (textBox != null)
        {
            textBox.SetActive(false);
        }

        // Instantiate a new object from the prefab
        objectToPlace = Instantiate(objectPrefab);

        // Assign object to the "Placement" layer to avoid interference during placement
        objectToPlace.layer = LayerMask.NameToLayer("Placement");

        isPlacing = true;
    }

    void PlaceObject(Vector3 snappedPosition)
    {
        // Check if the player still has enough gold to place the object
        if (goldManager.gold >= goldCost)
        {
            // Subtract gold when the object is placed
            goldManager.SpendGold(goldCost);
            Debug.Log($"Object placed, {goldCost} gold subtracted. Remaining gold: {goldManager.gold}");

            // Mark the grid cell as occupied
            buildGrid.OccupyCell(snappedPosition);

            // Reassign the object to its default layer (for normal interactions)
            objectToPlace.layer = LayerMask.NameToLayer("Structure");  

            // Show Panel1 after placement
            panel1.SetActive(true);

            // Hide the grid after placement
            buildGrid.HideGrid();
        }
        else
        {
            Debug.Log("Not enough gold to place the object!");
            CancelPlacement();
            return;
        }

        // Finalize the placement
        isPlacing = false;

        // Clear the reference to the placed object
        objectToPlace = null;
    }


    void FollowCursor()
    {
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
        Vector3 snappedPosition = SnapToGrid(worldPosition);

        objectToPlace.transform.position = new Vector3(snappedPosition.x, snappedPosition.y, 0f);
    }

    Vector3 SnapToGrid(Vector3 originalPosition)
    {
        if (buildGrid == null)
        {
            Debug.LogError("BuildGrid is null! Unable to snap to grid.");
            return originalPosition;
        }

        // Calculate the snapped position based on the grid cell size
        float x = Mathf.Round(originalPosition.x / buildGrid.CellSize) * buildGrid.CellSize;
        float y = Mathf.Round(originalPosition.y / buildGrid.CellSize) * buildGrid.CellSize;

        return new Vector3(x, y, 0f);
    }

    

    void CancelPlacement()
    {
        // Destroy the object and cancel the placement
        if (objectToPlace != null)
        {
            Destroy(objectToPlace);
        }

        // Show Panel1 after cancellation
        panel1.SetActive(true);

        // Hide the grid after cancellation
        buildGrid.HideGrid();

        isPlacing = false;

        // Clear the reference to the object
        objectToPlace = null;
    }
    
}
