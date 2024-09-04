using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Alien4Health : MonoBehaviour
{
    public event Action OnDestroyed;
    public float health;
    public float maxHealth = 150;
    public Slider slider;
    private Goldmanager goldManager;
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
        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject GameManagerWithGoldScript = GameObject.Find("Game manager");
            if (GameManagerWithGoldScript != null)
            {
                goldManager = GameManagerWithGoldScript.GetComponent<Goldmanager>();
                if (goldManager != null)
                {
                    goldManager.AddGold(4);
                    Debug.Log("2 Gold added");
                }
                else
                {
                    Debug.LogError("Gold could not be added");
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage taken, current health: " + health);
        if (health <= 0)
        {
            Destroyed();
        }
    }
    public void Destroyed()
    {
        Debug.Log("Alien destroyed!");
        OnDestroyed?.Invoke();
        Destroy(gameObject);
    }
}