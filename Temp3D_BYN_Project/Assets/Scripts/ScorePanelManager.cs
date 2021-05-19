/***************************************************
Enables the score panel visibility to be toggled by buttons.
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScorePanelManager : MonoBehaviour
{
    public GameObject ScorePanel;
    public Button OpenScorePanelButton;
    public Button CloseScorePanelButton;

    // Start is called before the first frame update
    void Start()
    {
        OpenScorePanelButton.onClick.AddListener(OpenScorePanel);
        CloseScorePanelButton.onClick.AddListener(CloseScorePanel);
    }


    // function that turns on score panel visibility
    public void OpenScorePanel()
    {
        if(ScorePanel != null)
        {
            ScorePanel.SetActive(true);
        }
    }

    //function that turns off score panel visibility
    public void CloseScorePanel()
    {
        if (ScorePanel != null)
        {
            ScorePanel.SetActive(false);
        }
    }
}
