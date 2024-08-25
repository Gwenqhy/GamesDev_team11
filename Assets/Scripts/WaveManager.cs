using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    public GameObject enemyPrefab;
    public int quantity;
    public float spawnDelay;
    public Transform[] spawners;
}

public class WaveManager : MonoBehaviour
{
    public List<EnemyWave> waves;
    private int currentWaveIndex = 0;

    public void StartWave(int waveIndex)
    {
        StartCoroutine(SpawnWave(waves[waveIndex]));
    }

    private IEnumerator SpawnWave(EnemyWave wave)
    {
        for (int i = 0; i < wave.quantity; i++)
        {
            // Choose a random spawner from the array
            Transform selectedSpawner = wave.spawners[Random.Range(0, wave.spawners.Length)];
            Instantiate(wave.enemyPrefab, selectedSpawner.position, Quaternion.identity);
            yield return new WaitForSeconds(wave.spawnDelay);
        }

        // Check for more waves or end the wave sequence
        if (currentWaveIndex < waves.Count - 1)
        {
            currentWaveIndex++;
            StartWave(currentWaveIndex);
        }
    }
}
