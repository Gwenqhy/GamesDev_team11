using System.Collections;
using UnityEngine;

public class enemyspawner3 : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
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

        // Get the Alien2Health component of the spawned enemy
        Alien2Health enemyHealth = spawnedEnemy.GetComponent<Alien2Health>();

        // Register the alien with the AlienManager
        AlienManager.Instance.RegisterAlien(enemyHealth);

        // Wait for the specified spawn interval before spawning the next enemy
        yield return new WaitForSeconds(spawnInterval);
    }
    }
}
