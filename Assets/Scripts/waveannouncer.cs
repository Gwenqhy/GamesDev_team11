


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveannouncer : MonoBehaviour
{
    public Text waveAnnouncementText; // Reference to the UI Text component for displaying wave announcements
    public AudioSource audioSource; // Reference to the AudioSource component for playing sounds
    public AudioClip countdown10Sec; // Sound for 10 seconds remaining
    public AudioClip countdown5Sec; // Sound for 5 seconds remaining
    public AudioClip waveSpawningSound; // Sound for when the wave spawns
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
            HandleCountdown(30f);
        }

        // Wave 1 spawning at 30 seconds
        else if (timer >= 30f && timer < 30f + Time.deltaTime)
        {
            AnnounceWave(1);
        }

        // Countdown for wave 2 (80-90 seconds)
        else if (timer >= 80f && timer < 90f)
        {
            HandleCountdown(90f);
        }

        // Wave 2 spawning at 90 seconds (1 min 30 seconds)
        else if (timer >= 90f && timer < 90f + Time.deltaTime)
        {
            AnnounceWave(2);
        }

        // Countdown for wave 3 (140-150 seconds)
        else if (timer >= 140f && timer < 150f)
        {
            HandleCountdown(150f);
        }

        // Wave 3 spawning at 150 seconds (2 min 30 seconds)
        else if (timer >= 150f && timer < 150f + Time.deltaTime)
        {
            AnnounceWave(3);
        }

        // Countdown for wave 4 (200-210 seconds)
        else if (timer >= 200f && timer < 210f)
        {
            HandleCountdown(210f);
        }

        // Wave 4 spawning at 210 seconds (3 min 30 seconds)
        else if (timer >= 210f && timer < 210f + Time.deltaTime)
        {
            AnnounceWave(4);
        }

        // Countdown for wave 5 (260-270 seconds)
        else if (timer >= 260f && timer < 270f)
        {
            HandleCountdown(270f);
        }

        // Wave 5 spawning at 270 seconds (4 min 30 seconds)
        else if (timer >= 270f && timer < 270f + Time.deltaTime)
        {
            AnnounceWave(5);
        }
    }

    // Handle Countdown
    void HandleCountdown(float waveSpawnTime)
    {
        float timeLeft = waveSpawnTime - timer;

        waveAnnouncementText.text = "Wave is spawning in " + Mathf.Ceil(timeLeft).ToString() + "s";

        // Play sound at specific countdown points (10 seconds and 5 seconds)
        if (Mathf.Ceil(timeLeft) == 10f)
        {
            audioSource.PlayOneShot(countdown10Sec);
        }
        else if (Mathf.Ceil(timeLeft) == 5f)
        {
            audioSource.PlayOneShot(countdown5Sec);
        }
    }

    void AnnounceWave(int waveNumber)
    {
        waveAnnouncementText.text = "Wave " + waveNumber + " is spawning!";
        audioSource.PlayOneShot(waveSpawningSound); // Play wave spawning sound
        StartCoroutine(ClearAnnouncementAfterDelay(30f)); // Clear the announcement after 30 seconds
    }

    IEnumerator ClearAnnouncementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        waveAnnouncementText.text = "";
    }
}
