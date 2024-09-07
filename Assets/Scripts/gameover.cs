/*This script manages the Game Over logic in the game. 
It monitors a GameObject's existence, triggers the Game Over panel when it's destroyed, 
pauses the game, and plays a game over sound. It also allows players 
to restart the game or quit to the main menu, with optional audio feedback 
for button clicks and the ability to mute or lower game music upon game over.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject objectToCheck; // Reference to the GameObject to monitor
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public Button retryButton; // Reference to retry button
    public Button quitButton; // Reference to quit button

    // Audio-related variables
    public AudioSource audioSource; // Reference to the AudioSource component for game over sound
    public AudioClip gameOverSound; // Audio clip to play on game over
    public AudioClip buttonClickSound; // (Optional) Audio clip for button clicks

    // Reference to the general game music AudioSource
    public AudioSource gameMusicAudioSource;

    private bool hasGameOverSoundPlayed = false; // Flag to track if the game over sound has been played

    void Start()
    {
        Time.timeScale = 1f; // Ensure time is running normally at the start of the scene
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Ensure the panel is hidden at the start
        }

        // Add listeners to the buttons with audio feedback
        quitButton.onClick.AddListener(() => {
            PlayButtonClickSound();
            QuitGame();
        });
        retryButton.onClick.AddListener(() => {
            PlayButtonClickSound();
            RestartGame();
        });

        // Ensure AudioSource is assigned
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component is missing from the GameObject.");
            }
        }
    }

    void Update()
    {
        if (objectToCheck == null && !hasGameOverSoundPlayed) // Ensure the sound is only played once
        {
            Debug.Log("The object has been destroyed. Showing game over panel.");
            ShowGameOverPanel();
        }
    }

    void ShowGameOverPanel()
    {
        Time.timeScale = 0f; // Pause the game
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the Game Over panel
        }

        // Mute or lower the game music volume to avoid overlap
        if (gameMusicAudioSource != null)
        {
            gameMusicAudioSource.volume = 0f; // Set the volume to 0 or pause the music
        }

        // Play game over sound once
        if (audioSource != null && gameOverSound != null && !hasGameOverSoundPlayed)
        {
            audioSource.PlayOneShot(gameOverSound);
            hasGameOverSoundPlayed = true; // Ensure the sound is not played again
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting the game...");
        Time.timeScale = 1f; // Reset time scale to normal speed

        // Restore game music volume
        if (gameMusicAudioSource != null)
        {
            gameMusicAudioSource.volume = 1f; // Restore the volume
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting to Main Menu...");

        // Restore game music volume (optional if needed in the main menu)
        if (gameMusicAudioSource != null)
        {
            gameMusicAudioSource.volume = 1f; // Restore the volume
        }

        SceneManager.LoadSceneAsync("MainMenu"); // Return to main menu
    }

    // Play button click sound
    void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
