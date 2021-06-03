using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HousingGoalController : MonoBehaviour
{
    public Image bar;
    public Text perc;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*bar.fillAmount -= .001f;
        float j = (1 * bar.fillAmount);
        string goal = j.ToString("n2");
        goal = goal.Substring(2, 2);
        perc.text = goal + "%";*/
    }

    // takes a scoreholder object, parses out the housing/quality of life score, and displays it on the screen 
    public void updateScore(Scoreholder scoreholder)
    {
        float score = scoreholder.qualLifePts;
        Debug.Log("bar fill amount: " + bar.fillAmount + ", score: " + score);
        float fill = score / 200f;
        bar.fillAmount = fill;
        perc.text = score.ToString();
    }
}
