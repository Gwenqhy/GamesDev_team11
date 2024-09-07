/*This script checks for the defeat of all enemies in the scene, 
triggering a victory condition. It continuously checks for remaining 
enemies after a delay and shows a victory panel when no enemies remain. 
The script also handles pausing the game, playing a victory sound, 
muting game music, and providing options to restart the game or quit 
to the main menu, with audio feedback for each action.*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyDefeatChecker : MonoBehaviour
{
    public GameObject victoryPanel; // The panel to display when all enemies are defeated
    public float checkDelay = 10f; // Delay before starting to check for the win condition
    public float checkInterval = 1f; // Interval between each check
    public Button retryButton; // Button component
    public Button quitButton; // Button component

    // Audio-related variables
    public AudioSource victoryAudioSource; // AudioSource for the victory sound
    public AudioClip victorySound; // Victory sound clip

    public AudioSource gameMusicAudioSource; // Reference to the AudioSource for the general game music

    private bool hasVictorySoundPlayed = false; // Flag to ensure victory sound is played once

    void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false); // Ensure the panel is hidden at the start
        }

        InvokeRepeating("CheckEnemies", checkDelay, checkInterval);

        // Add listeners to the buttons
        quitButton.onClick.AddListener(QuitGame);
        retryButton.onClick.AddListener(RestartGame);

        // Ensure victory audio source is assigned
        if (victoryAudioSource == null)
        {
            victoryAudioSource = GetComponent<AudioSource>();
            if (victoryAudioSource == null)
            {
                Debug.LogError("AudioSource for victory sound is missing from the GameObject.");
            }
        }
    }

    // Coroutine to start checking for the win condition after a delay
    private void CheckEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Check if there are any enemies left in the scene
        if (enemies.Length == 0 && !hasVictorySoundPlayed) // Check that enemies are gone and victory sound has not played
        {
            Debug.Log("No enemies left in the scene.");
            ShowVictoryPanel();
            CancelInvoke("CheckEnemies"); // Stop further checks
        }
        else
        {
            Debug.Log("Enemies still exist in the scene.");
        }
    }

    // Method to display the victory panel and play victory sound
    private void ShowVictoryPanel()
    {
        Time.timeScale = 0f; // Pause the game
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true); // Show the victory panel
        }

        // Lower or mute the game music to avoid overlap
        if (gameMusicAudioSource != null)
        {
            gameMusicAudioSource.volume = 0f; // Set the volume to 0 or pause the music
        }

        // Play the victory sound once
        if (victoryAudioSource != null && victorySound != null && !hasVictorySoundPlayed)
        {
            victoryAudioSource.PlayOneShot(victorySound);
            hasVictorySoundPlayed = true; // Ensure victory sound is not played again
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting the game...");
        Time.timeScale = 1f; // Reset time scale to normal speed

        // Restore the game music volume
        if (gameMusicAudioSource != null)
        {
            gameMusicAudioSource.volume = 1f; // Restore the volume to its original value
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void QuitGame()
    {
        Debug.Log("Returning to Main Menu...");

        // Restore the game music volume (optional if you want to keep music in the menu)
        if (gameMusicAudioSource != null)
        {
            gameMusicAudioSource.volume = 1f; // Restore volume before transitioning to the menu
        }

        SceneManager.LoadSceneAsync("MainMenu"); // Return to the main menu
    }
}
