using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampOneSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;  // The prefab with a SpriteRenderer


    [SerializeField]
    private float spawnRate = 2f;  // spawnrate of enemies

    [SerializeField]
    private float spawnRadius = 3f;    // spawn radius


    void Start()
    {
        if (prefabs.Length != 2)
        {
           
            return;
        }
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnTroops();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnTroops()
    {
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Choose a random prefab from the array
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        // Instantiate the prefab at the generated position
        GameObject newObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
