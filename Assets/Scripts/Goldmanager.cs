using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Goldmanager : MonoBehaviour
{
    public float gold = 0f; // The current amount of gold
    public Text goldText; // Text component gold
    public float goldIncreaseInterval = 1f; // Time interval for gold increase (1/second)
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

    public void AddGold(float amount) //function to add gold
    {
        gold += amount;
        UpdateGoldUI();
    }

    public void SpendGold(float amount) // function to spend gold
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateGoldUI();
        }
        else //not enough gold
        {
            Debug.Log("Not enough gold!");
        }
    }

    void UpdateGoldUI()
    {
        goldText.text = ": " + Math.Floor(gold).ToString();
    }
}