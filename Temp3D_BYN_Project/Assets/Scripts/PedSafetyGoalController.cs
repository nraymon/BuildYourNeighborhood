using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PedSafetyGoalController : MonoBehaviour
{

    public Image bar;
    public Text perc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount -= .001f;
        float j = (1 * bar.fillAmount);
        string goal = j.ToString("n2");
        goal = goal.Substring(2, 2);
        perc.text = goal + "%";
    }
}
