using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab of the object to be instantiated and placed
    public Button placeButton; // The button that initiates the placement process
    public Goldmanager goldManager; // Reference to the GoldManager script

    public GameObject panel1; // Reference to Panel1 to hide during placement and show after placement
    public int goldCost = 20; // The gold cost to place the object, changeable in the Inspector

    private GameObject objectToPlace; // Reference to the currently placing object
    private bool isPlacing = false; // Tracks whether the object is currently being placed

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
        isPlacing = true;
    }

    void FollowCursor()
    {
        // Get the cursor position in world space
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = 10f; // Set z distance from the camera (adjust as needed)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        // Set the object's position to the cursor's position
        objectToPlace.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);
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
