using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Ally;

    [SerializeField]
    private float spawnerInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnerInterval, Ally));
    }

    private IEnumerator spawnEnemy(float interval,GameObject ally)
    {
        yield return new WaitForSeconds(interval);
        GameObject newAlly = Instantiate(ally, new Vector3(transform.position.x , transform.position.y ,0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, ally));
    }
}
