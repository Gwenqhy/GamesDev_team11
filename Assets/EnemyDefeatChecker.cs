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
    public Button retryButton;
    public Button quitButton;
    

    void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false); // Ensure the panel is hidden at the start
        }

        InvokeRepeating("CheckEnemies", checkDelay, checkInterval);
        quitButton.onClick.AddListener(QuitGame);
        retryButton.onClick.AddListener(RestartGame);
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
            CancelInvoke("CheckForEnemies"); // Stop further checks
        }
        else
        {
            Debug.Log("Enemies still exist in the scene.");
        }
    }

    
    // Method to display the victory panel
    private void ShowVictoryPanel()
    {
        Time.timeScale = 0f; // Pause the game
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true); // Show the victory panel
        }
    }

    public void RestartGame()
    {
        Debug.Log("Restarting the game...");
        Time.timeScale = 1f; // Reset time scale to normal speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");//return to main menu
    }
}
