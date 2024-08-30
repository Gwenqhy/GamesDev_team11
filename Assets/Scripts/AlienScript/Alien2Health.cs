using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Alien2Health : MonoBehaviour
{
    public event Action OnDestroyed;
    public float health;
    public float maxHealth = 150;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

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
        OnDestroyed?.Invoke();
        Destroy(gameObject);
    }
}