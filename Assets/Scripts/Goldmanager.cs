using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goldmanager : MonoBehaviour
{
    public int gold = 0; // The current amount of gold
    public Text goldText; // Reference to the UI Text component that displays the gold
    public float goldIncreaseInterval = 1f; // Time interval for gold increase (1 second)

    private float timer = 0f;

    void Start()
    {
        // Initialize the gold display
        UpdateGoldUI();
    }

    void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Check if the timer has reached the gold increase interval
        if (timer >= goldIncreaseInterval)
        {
            AddGold(1); // Increase gold by 1
            timer = 0f; // Reset the timer
        }
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldUI();
    }

    public void SpendGold(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateGoldUI();
        }
        else
        {
            Debug.Log("Not enough gold!");
        }
    }

    void UpdateGoldUI()
    {
        goldText.text = "Gold: " + gold.ToString();
    }
}