﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHealth : MonoBehaviour
{
    public double health;
    public double maxHealth = 6.25;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
