﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp3Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabs;  // The prefab with a SpriteRenderer


    [SerializeField]
    private float spawnRate = 2f;  // spawnrate of enemies

    [SerializeField]
    private float spawnRadius = 3f;    // spawn radius


    void Start()
    {
        if (prefabs.Length != 1)
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

    
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        GameObject newObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}

