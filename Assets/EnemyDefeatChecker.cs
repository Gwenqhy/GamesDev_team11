using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDefeatChecker : MonoBehaviour
{
    [SerializeField]
    private string enemyTag = "Wave1Enemy"; // Tag to identify wave 1 enemies

    [SerializeField]
    private float checkInterval = 1f; // Time interval between each check (in seconds)

    [SerializeField]
    private float initialDelay = 30f; // Delay before starting the check (in seconds)

    private int totalEnemies; // Total number of enemies that should be spawned across all spawners
    private int destroyedEnemies = 0; // Counter for destroyed enemies

    // Start is called before the first frame update
    void Start()
    {
        // Start the checking process after the specified initial delay
        StartCoroutine(CheckForEnemiesAfterDelay());
    }

    // This method is called by each spawner to add to the total number of enemies
    public void AddToTotalEnemies(int count)
    {
        totalEnemies += count;
    }

    // This method is called by each spawner to register a spawned enemy
    public void RegisterSpawnedEnemy(Alien2Health enemy)
    {
        // Listen for the enemy's destruction event
        enemy.OnDestroyed += OnEnemyDestroyed;
    }

    private IEnumerator CheckForEnemiesAfterDelay()
    {
        // Wait for the initial delay
        yield return new WaitForSeconds(initialDelay);

        // Start checking periodically if all enemies are gone
        StartCoroutine(CheckIfAllEnemiesRemoved());
    }

    private IEnumerator CheckIfAllEnemiesRemoved()
    {
        while (true)
        {
            // Check if the count of destroyed enemies equals the total number of enemies
            if (destroyedEnemies >= totalEnemies)
            {
                OnAllEnemiesRemoved();
                yield break; // Stop checking
            }

            // Wait for the next check interval
            yield return new WaitForSeconds(checkInterval);
        }
    }

    // This method is called when an enemy is destroyed
    private void OnEnemyDestroyed()
    {
        destroyedEnemies++;

        // Immediately check if all enemies have been removed
        if (destroyedEnemies >= totalEnemies)
        {
            OnAllEnemiesRemoved();
        }
    }

    private void OnAllEnemiesRemoved()
    {
        // Logic to handle when all enemies are removed
        Debug.Log("All Wave 1 enemies have been removed!");

        // Example: Display a victory message, load the next wave, etc.
        // You can trigger any other event here
    }
}
