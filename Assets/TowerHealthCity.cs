using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthCity : MonoBehaviour
{
    public float health;
    public float maxHealth = 500;
    public Slider slider;
    public GameObject gameOverPanel;

    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        gameOverPanel.SetActive(false); // Ensure the panel is hidden at the start
        Debug.Log("Game started. City health: " + health);
    }

    void Update()
    {
        slider.value = health;
        if (health <= 0)
        {
            Debug.Log("Health reached zero. Destroying city...");
            Destroy(slider.gameObject);
            DestroyCity();
        }
    }
    void DestroyCity()
    {
        Debug.Log("DestroyCity method called. Pausing game and showing panel.");
        gameOverPanel.SetActive(true); // Show the Game Over panel
        Destroy(gameObject); // Destroy the city
    }
}
