/***************************************************
Enables the score panel visibility to be toggled by buttons.
Controls the score text that appears in the scorepanel. 
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScorePanelManager : MonoBehaviour
{
    public GameObject ScorePanel;               // scorepanel UI object itself
    public Button OpenScorePanelButton;         // button to open the scorepanel
    public Button CloseScorePanelButton;        // button to close the scorepanel (an x on the panel itself)

    public Transform scoreContainer;            // used to manipulate the scorepanel text container
    public Transform scoreTemplate;             // used to manipulate the score text template 

    public List<ScoreEntry> scoreEntryList;     // list of score entries to be displayed in the scorepanel
    public List<Transform> scoreEntryTransformList;

    // Start is called before the first frame update- init and hook functions up to UI here
    void Start()
    {
        OpenScorePanelButton.onClick.AddListener(OpenScorePanel);
        CloseScorePanelButton.onClick.AddListener(CloseScorePanel);

        scoreEntryList = new List<ScoreEntry>();

        // get references to the score panel and entry templates
        scoreContainer = transform.Find("ScorePanel/ScorePanelScrollable/ScorePanelEntryContainer");
        scoreTemplate = transform.Find("ScorePanel/ScorePanelScrollable/ScorePanelEntryContainer/ScorePanelEntryTemplate");

        //hide default score template 
        scoreTemplate.gameObject.SetActive(false);
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

    // This function constantly listens to changes to the scorepanel while the game is running 
    public void Awake()
    {
        
    }


    public void UpdateScorePanel(List<Scoreholder> scoreHolderList)
    {
        // split each scoreholder object into three entries in the scorepanel
        foreach (Scoreholder scoreHolder in scoreHolderList)
        {
            ScoreEntry floodEntry = new ScoreEntry();
            floodEntry.points = scoreHolder.floodPts.ToString();
            floodEntry.description = scoreHolder.floodDesc;
            floodEntry.goal = "Flood";
            floodEntry.interaction = scoreHolder.tileOne + ",\n" + scoreHolder.tileTwo;

            ScoreEntry pedSafetyEntry = new ScoreEntry();
            pedSafetyEntry.points = scoreHolder.pedSafetyPts.ToString();
            pedSafetyEntry.description = scoreHolder.pedSafetyDesc;
            pedSafetyEntry.goal = "Pedestrian\nSafety";
            pedSafetyEntry.interaction = scoreHolder.tileOne + ",\n" + scoreHolder.tileTwo;

            ScoreEntry qualLifeEntry = new ScoreEntry();
            qualLifeEntry.points = scoreHolder.qualLifePts.ToString();
            qualLifeEntry.description = scoreHolder.qualLifeDesc;
            qualLifeEntry.goal = "Housing &\nQual of Life";
            qualLifeEntry.interaction = scoreHolder.tileOne + ",\n" + scoreHolder.tileTwo;

            // add the new score entry objects to the score entry list
            scoreEntryList.Add(floodEntry);
            scoreEntryList.Add(pedSafetyEntry);
            scoreEntryList.Add(qualLifeEntry);
        }

        // put the score entries into template holders in the scorepanel
        scoreEntryTransformList = new List<Transform>();
        foreach (ScoreEntry scoreEntry in scoreEntryList)
        {
            CreateScoreEntryTransform(scoreEntry, scoreContainer, scoreEntryTransformList);
        }
    }


    // takes a ScoreEntry object and inserts it into the scorepanel container. 
    public void CreateScoreEntryTransform(ScoreEntry scoreEntry, Transform scoreContainer, List<Transform> transformList)
    {
        float templateHeight = 295f;
        Transform scoreTransform = Instantiate(scoreTemplate, scoreContainer);
        RectTransform scoreRectTransform = scoreTransform.GetComponent<RectTransform>();
        scoreRectTransform.anchoredPosition = new Vector2(0, templateHeight - (85f * transformList.Count));
        scoreTransform.gameObject.SetActive(true);

        scoreTransform.Find("Interaction").GetComponent<Text>().text = scoreEntry.interaction;
        scoreTransform.Find("Goal").GetComponent<Text>().text = scoreEntry.goal;
        scoreTransform.Find("Points").GetComponent<Text>().text = scoreEntry.points;
        scoreTransform.Find("Description").GetComponent<Text>().text = scoreEntry.description;

        transformList.Add(scoreTransform);
    }



    // represents a score text entry. helps with passing in new score text into the panel.
    public class ScoreEntry
    {
        public string interaction;
        public string goal;
        public string points;
        public string description;
    }
}
