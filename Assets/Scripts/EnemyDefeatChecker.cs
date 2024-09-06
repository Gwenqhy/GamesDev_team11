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
        if (enemies.Length == 0)
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

        // Play the victory sound
        if (victoryAudioSource != null && victorySound != null)
        {
            victoryAudioSource.PlayOneShot(victorySound);
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
