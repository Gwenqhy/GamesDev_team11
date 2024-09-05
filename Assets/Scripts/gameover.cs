using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject objectToCheck; // Reference to the GameObject to monitor
    public GameObject gameOverPanel; // Reference to the Game Over panel
    public Button retryButton;
    public Button quitButton;

    void Start()
    {
        Time.timeScale = 1f; // Ensure time is running normally at the start of the scene
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Ensure the panel is hidden at the start
        }
        
        // Add listeners to the buttons
        quitButton.onClick.AddListener(QuitGame);
        retryButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (objectToCheck == null)
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
