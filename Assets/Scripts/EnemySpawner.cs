using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private float spawnerInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnerInterval, Enemy));
    }

    private IEnumerator spawnEnemy(float interval,GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(transform.position.x , transform.position.y, 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
