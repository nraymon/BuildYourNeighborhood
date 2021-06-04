/***************************************************
Enables the end game panel to be toggled by buttons.
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndGameController : MonoBehaviour
{
    public GameObject EndGamePanel;
    public GameObject BackgroundPanel;
    public Button OpenPanelButton;
    public Button ClosePanelButton;
    public Button DoneButton;


    // Start is called before the first frame update
    void Start()
    {
        OpenPanelButton.onClick.AddListener(OpenEndGamePanel);
        ClosePanelButton.onClick.AddListener(CloseEndGamePanel);
    }


    // function that turns on end game panel visibility
    public void OpenEndGamePanel()
    {
        if (EndGamePanel != null)
        {
            EndGamePanel.SetActive(true);
            BackgroundPanel.SetActive(true);
        }
    }

    //function that turns off end game panel visibility
    public void CloseEndGamePanel()
    {
        if (EndGamePanel != null)
        {
            EndGamePanel.SetActive(false);
            BackgroundPanel.SetActive(false);
        }
    }

    public void Awake()
    {
        
    }
}
