using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICONTROL : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public Button button1;
    public Button button2;
    public Button closeButton2;
    public Button restartButton;
    public Button settingsButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure no panels are active initially
        panel1.SetActive(false);
        panel2.SetActive(false);
    

        // Add listeners to the buttons
        button1.onClick.AddListener(TogglePanel1);
        button2.onClick.AddListener(TogglePanel2);
        closeButton2.onClick.AddListener(() => HidePanel(panel2));
        restartButton.onClick.AddListener(RestartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale to normal speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void OpenSettings()
    {

    }

    public void CloseSettings()
    {
        
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        // Uncomment the following line when building the game
        // Application.Quit();
    }

    void TogglePanel1()
    {
        if (panel1.activeSelf)
        {
            HidePanel(panel1); // Hide panel2 if it is already active
        }
        else
        {
            ShowPanel(panel1); // Show panel2 if it is not active
        }
    }

    void TogglePanel2()
    {
        if (panel2.activeSelf)
        {
            HidePanel(panel2); // Hide panel2 if it is already active
        }
        else
        {
            ShowPanel(panel2); // Show panel2 if it is not active
        }
    }

    void ShowPanel(GameObject panelToShow)
    {
        panelToShow.SetActive(true);

        if (panelToShow == panel2)
        {
            Time.timeScale = 0f; // Pauses the game
        }
    }

    void HidePanel(GameObject panelToHide)
    {
        panelToHide.SetActive(false);

        if (panelToHide == panel2)
        {
            Time.timeScale = 1f; // Resumes the game
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle panel2 visibility
            if (!panel2.activeSelf)
            {
                ShowPanel(panel2);
            }
            else
            {
                HidePanel(panel2);
            }
        }
    }
}
