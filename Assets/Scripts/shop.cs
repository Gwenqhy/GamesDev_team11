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

    public GameObject panel1; // Reference to Panel1 to hide during placement and show after placement
    public int goldCost = 20; // The gold cost to place the object, changeable in the Inspector

    private GameObject objectToPlace; // Reference to the currently placing object
    private bool isPlacing = false; // Tracks whether the object is currently being placed
    private BuildGrid buildGrid; // Reference to the grid for snapping
    

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
                PlaceObject();
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
		
		    // Instantiate a new object from the prefab
		    objectToPlace = Instantiate(objectPrefab);
		    objectToPlace.transform.localScale = Vector3.one; // Ensure it's at normal scale
		    isPlacing = true;
		
		    Debug.Log("Object scale: " + objectToPlace.transform.localScale);
		}


	void FollowCursor()
	{
	    Vector3 cursorPosition = Input.mousePosition;
	    cursorPosition.z = Mathf.Abs(Camera.main.transform.position.z);
	    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
	    Vector3 snappedPosition = SnapToGrid(worldPosition);
	
	    Debug.Log("Cursor Position: " + cursorPosition);
	    Debug.Log("World Position: " + worldPosition);
	    Debug.Log("Snapped Position: " + snappedPosition);
	
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


    void PlaceObject()
    {
        // Check if the player still has enough gold to place the object
        if (goldManager.gold >= goldCost)
        {
            // Subtract gold when the object is placed
            goldManager.SpendGold(goldCost);
            Debug.Log($"Object placed, {goldCost} gold subtracted. Remaining gold: {goldManager.gold}");

            // Show Panel1 after placement
            panel1.SetActive(true);
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

    void CancelPlacement()
    {
        // Destroy the object and cancel the placement
        if (objectToPlace != null)
        {
            Destroy(objectToPlace);
        }

        // Show Panel1 after cancellation
        panel1.SetActive(true);

        isPlacing = false;

        // Clear the reference to the object
        objectToPlace = null;
    }
}