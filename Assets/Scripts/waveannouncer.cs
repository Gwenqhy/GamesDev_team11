using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveannouncer : MonoBehaviour
{
    public Text waveAnnouncementText; // Reference to the UI Text component for displaying wave announcements
    private float timer = 0f;

    void Start()
    {
        // Initialize the wave announcement display
        waveAnnouncementText.text = "Preparation Phase";
    }

    void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Preparation phase (0-20 seconds)
        if (timer < 20f)
        {
            waveAnnouncementText.text = "Preparation Phase";
        }

        // Countdown for wave 1 (20-30 seconds)
        else if (timer >= 20f && timer < 30f)
        {
            float timeLeft = 30f - timer;
            waveAnnouncementText.text = "Wave 1 is spawning in " + Mathf.Ceil(timeLeft).ToString() + "s";
        }

        // Wave 1 spawning at 30 seconds
        else if (timer >= 30f && timer < 30f + Time.deltaTime)
        {
            AnnounceWave(1);
        }

        // Countdown for wave 2 (80-90 seconds)
        else if (timer >= 80f && timer < 90f)
        {
            float timeLeft = 90f - timer;
            waveAnnouncementText.text = "Wave 2 is spawning in " + Mathf.Ceil(timeLeft).ToString() + "s";
        }

        // Wave 2 spawning at 90 seconds (1 min 30 seconds)
        else if (timer >= 90f && timer < 90f + Time.deltaTime)
        {
            AnnounceWave(2);
        }
        // Countdown for wave 3 (140-150 seconds)
        else if (timer >= 140f && timer < 150f)
        {
            float timeLeft = 150f - timer;
            waveAnnouncementText.text = "Wave 3 is spawning in " + Mathf.Ceil(timeLeft).ToString() + "s";
        }

        // Wave 3 spawning at 150 seconds (2 min 30 seconds)
        else if (timer >= 150f && timer < 150f + Time.deltaTime)
        {
            AnnounceWave(3);
        }
                // Countdown for wave 4 (200-210 seconds)
        else if (timer >= 200f && timer < 210f)
        {
            float timeLeft = 210f - timer;
            waveAnnouncementText.text = "Wave 4 is spawning in " + Mathf.Ceil(timeLeft).ToString() + "s";
        }

        // Wave 4 spawning at 150 seconds (3 min 30 seconds)
        else if (timer >= 210f && timer < 210f + Time.deltaTime)
        {
            AnnounceWave(4);
        }
                // Countdown for wave 5 (260-270 seconds)
        else if (timer >= 260f && timer < 270f)
        {
            float timeLeft = 270f - timer;
            waveAnnouncementText.text = "Wave 5 is spawning in " + Mathf.Ceil(timeLeft).ToString() + "s";
        }

        // Wave 5 spawning at 270 seconds (3 min 30 seconds)
        else if (timer >= 270f && timer < 270f + Time.deltaTime)
        {
            AnnounceWave(5);
        }
    }

    void AnnounceWave(int waveNumber)
    {
        waveAnnouncementText.text = "Wave " + waveNumber + " is spawning!";
        StartCoroutine(ClearAnnouncementAfterDelay(30f)); // Clear the announcement after 30 seconds
    }

    IEnumerator ClearAnnouncementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        waveAnnouncementText.text = "";
    }
}

