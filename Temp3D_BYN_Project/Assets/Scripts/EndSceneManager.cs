using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    public Text floodScoreText; // flood prevention score that displays on end scene
    public Text pedSafetyScoreTExt; // pedestrian safety score that displays on end scene
    public Text qualLifeScoreText; // quality of life score that displays on end scene

    // Start is called before the first frame update
    void Start()
    {
        // Load the three score values from Player Prefs and display on the scene's UI 
        float floodPts = PlayerPrefs.GetFloat("floodPts");
        float pedSafetyPts = PlayerPrefs.GetFloat("pedSafetyPts");
        float qualLifePts = PlayerPrefs.GetFloat("qualLifePts");

        floodScoreText.text = floodPts.ToString();
        pedSafetyScoreTExt.text = pedSafetyPts.ToString();
        qualLifeScoreText.text = qualLifePts.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
