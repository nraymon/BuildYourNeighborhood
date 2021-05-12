using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayController : MonoBehaviour
{
    public Text scoreVal; // text that displays the score on screen

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // takes a 
    public void updateScore(Scoreholder scoreholder)
    {
        int score = scoreholder.getCombinedScore();
        scoreVal.text = score.ToString();
    }
}
