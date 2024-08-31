using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDefeatChecker : MonoBehaviour
{
    public GameObject victoryPanel; // The panel to display when all enemies are defeated
    public float checkDelay = 30f; // Delay before starting to check for the win condition

    private int totalEnemies = 0; // Total number of enemies that should be defeated
    private int enemiesDefeated = 0; // Count of enemies defeated
    private bool checkingForWin = false;

    void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false); // Ensure the panel is hidden at the start
        }

        // Start the coroutine that will enable checking for the win condition after a delay
        StartCoroutine(StartCheckingForWinCondition());
    }

    // Coroutine to start checking for the win condition after a delay
    private IEnumerator StartCheckingForWinCondition()
    {
        yield return new WaitForSeconds(checkDelay); // Wait for the specified delay
        checkingForWin = true; // Enable win condition checking
    }

    // Call this method from the spawner to add to the total enemy count
    public void AddToTotalEnemies(int number)
    {
        totalEnemies += number;
    }

    // Call this method when an enemy is registered by the spawner
    public void RegisterSpawnedEnemy(Alien2Health alienHealth)
    {
        alienHealth.OnDestroyed += OnEnemyDestroyed;
    }

    // Method called when an enemy is destroyed
    private void OnEnemyDestroyed()
    {
        if (!checkingForWin)
            return; // Do nothing if we aren't yet checking for the win condition

        enemiesDefeated++;

        // Check if all enemies have been defeated
        if (enemiesDefeated >= totalEnemies)
        {
            ShowVictoryPanel();
        }
    }

    // Method to display the victory panel
    private void ShowVictoryPanel()
    {
        Time.timeScale = 0f; // Pause the game
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true); // Show the victory panel
        }
    }
}
