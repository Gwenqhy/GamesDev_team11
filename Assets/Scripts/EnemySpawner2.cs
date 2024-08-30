﻿using System.Collections;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // The type of enemy to spawn, set in the Inspector

    [SerializeField]
    private int numberOfEnemies = 5; // Number of enemies to spawn, set in the Inspector

    [SerializeField]
    private float spawnInterval = 1f; // Time interval between spawns, set in the Inspector

    [SerializeField]
    private float startDelay = 60f; // Delay before starting the spawn (in seconds)

    [SerializeField]
    private Vector3 enemySize = new Vector3(1, 1, 1); // Size of the spawned enemy, set in the Inspector

    [SerializeField]
    private string enemyTag = "Wave1Enemy"; // Tag to assign to spawned enemies

    private EnemyDefeatChecker defeatChecker;

    // Start is called before the first frame update
    void Start()
    {
        // Find the EnemyDefeatChecker in the scene
        defeatChecker = FindObjectOfType<EnemyDefeatChecker>();

        // Notify the EnemyDefeatChecker about the number of enemies to be spawned
        if (defeatChecker != null)
        {
            defeatChecker.AddToTotalEnemies(numberOfEnemies);
        }

        // Start the spawning process after the specified delay
        StartCoroutine(SpawnEnemiesAfterDelay());
    }

    private IEnumerator SpawnEnemiesAfterDelay()
    {
        // Wait for the specified start delay
        yield return new WaitForSeconds(startDelay);

        // Begin spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Spawn an enemy at the spawner's position
            GameObject spawnedEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            // Adjust the size of the spawned enemy
            spawnedEnemy.transform.localScale = enemySize;

            // Assign the enemy tag to the spawned enemy
            spawnedEnemy.tag = enemyTag;

            // Register the alien's OnDestroyed event with the defeatChecker
            Alien2Health alienHealth = spawnedEnemy.GetComponent<Alien2Health>();
            if (alienHealth != null && defeatChecker != null)
            {
                defeatChecker.RegisterSpawnedEnemy(alienHealth);
            }

            // Wait for the specified spawn interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
