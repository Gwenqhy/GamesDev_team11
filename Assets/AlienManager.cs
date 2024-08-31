using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienManager : MonoBehaviour
{
    public static AlienManager Instance; // Singleton instance

    private List<Alien2Health> allAliens = new List<Alien2Health>(); // List to keep track of all spawned aliens
    public GameObject victoryPanel; // The panel to bring up when all aliens are destroyed

    [SerializeField]
    private float delayBeforeCheck = 2f; // Delay before checking if all aliens are destroyed after each alien is destroyed, settable in the UI

    [SerializeField]
    private float startCheckDelay = 30f; // Delay before starting to check if all aliens are destroyed, settable in the UI

    private bool canStartChecking = false; // Flag to start checking only after the delay

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Set the victory panel to inactive at the start
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
            Debug.Log("Victory panel is set to inactive at the start.");
        }
        else
        {
            Debug.LogError("Victory panel is not assigned!");
        }

        // Start the coroutine to enable checking after the start delay
        StartCoroutine(StartCheckingAfterDelay());
    }

    private IEnumerator StartCheckingAfterDelay()
    {
        Debug.Log($"Starting check after {startCheckDelay} seconds.");
        yield return new WaitForSeconds(startCheckDelay);

        // Enable checking
        canStartChecking = true;
        Debug.Log("Now checking for remaining aliens.");
    }

    public void RegisterAlien(Alien2Health alien)
    {
        if (alien != null)
        {
            allAliens.Add(alien);
            alien.OnDestroyed += OnAlienDestroyed;
            Debug.Log("Alien registered with the AlienManager.");
        }
        else
        {
            Debug.LogError("Attempted to register a null alien.");
        }
    }

    private void OnAlienDestroyed()
    {
        if (canStartChecking)
        {
            Debug.Log("An alien was destroyed, starting delayed check.");
            // Start the delayed check coroutine
            StartCoroutine(DelayedCheck());
        }
        else
        {
            Debug.Log("An alien was destroyed but checking is not yet enabled.");
        }
    }

    private IEnumerator DelayedCheck()
    {
        // Wait for the specified delay before checking after an alien is destroyed
        yield return new WaitForSeconds(delayBeforeCheck);

        // Remove destroyed aliens from the list
        allAliens.RemoveAll(alien => alien == null);
        Debug.Log($"Remaining aliens after check: {allAliens.Count}");

        // Check if all aliens are destroyed
        if (allAliens.Count == 0 && canStartChecking)
        {
            Debug.Log("All aliens have been defeated! Showing victory panel.");
            victoryPanel.SetActive(true); // Bring up the victory panel
        }
    }
}
