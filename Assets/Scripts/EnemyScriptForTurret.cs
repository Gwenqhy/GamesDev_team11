﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptForTurret : MonoBehaviour
{
    [SerializeField] private int health = 100; 

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroyed();
        }
    }
    public void Destroyed()
    {
        Destroy(gameObject);
    }
}
