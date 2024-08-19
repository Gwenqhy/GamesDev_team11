using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private float spawnerTimeInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
  
            GameObject enemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

  
            Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

 
            yield return new WaitForSeconds(spawnerTimeInterval);
        }
    }
}
