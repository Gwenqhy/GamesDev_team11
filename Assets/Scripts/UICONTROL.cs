using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICONTROL : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public Button button1;
    public Button button2;
    public Button closeButton1;
    public Button closeButton2;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure no panels are active initially
        panel1.SetActive(false);
        panel2.SetActive(false);

        // Add listeners to the buttons
        button1.onClick.AddListener(() => ShowPanel(panel1, panel2));
        button2.onClick.AddListener(() => ShowPanel(panel2, panel1));
        closeButton1.onClick.AddListener(() => HidePanel(panel1));
        closeButton2.onClick.AddListener(() => HidePanel(panel2));
    }

    void ShowPanel(GameObject panelToShow, GameObject panelToHide)
    {
        panelToShow.SetActive(true);
        panelToHide.SetActive(false);
    }

    void HidePanel(GameObject panelToHide)
    {
        panelToHide.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if necessary
    }
}
