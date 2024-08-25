using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text component for displaying the timer
    private float timer = 0f;

    void Start()
    {
        // Initialize the timer display
        UpdateTimerUI(0, 0);
    }

    void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Calculate minutes and seconds from the timer
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Update the timer UI
        UpdateTimerUI(minutes, seconds);
    }

    void UpdateTimerUI(int minutes, int seconds)
    {
        // Format the timer as "mm:ss"
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
