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

    public Transform scoreContainer;
    public Transform scoreTemplate;

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

    public void Awake()
    {
        // get references to the score panel and entry templates
        scoreContainer = transform.Find("ScorePanel/ScorePanelScrollable/ScorePanelEntryContainer");
        scoreTemplate = transform.Find("ScorePanel/ScorePanelScrollable/ScorePanelEntryContainer/ScorePanelEntryTemplate");

        //hide default template 
        scoreTemplate.gameObject.SetActive(false);

        float templateHeight = 295f;
        // fill container with random entries 
        for (int i=0; i<10; i++)
        {
            Transform scoreTransfom = Instantiate(scoreTemplate, scoreContainer);
            RectTransform scoreRectTransform = scoreTransfom.GetComponent<RectTransform>();
            scoreRectTransform.anchoredPosition = new Vector2(0, templateHeight - (66f * i));
            scoreTransfom.gameObject.SetActive(true);
        }
    }
}
