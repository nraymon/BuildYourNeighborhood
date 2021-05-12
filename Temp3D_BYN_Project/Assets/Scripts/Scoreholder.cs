using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreholder
{
    public float floodPts;
    public float pedSafetyPts;
    public float qualLifePts;

    public string floodDesc;
    public string pedSafetyDesc;
    public string qualLifeDesc;

    public Scoreholder()
    {
        floodPts = 0f;
        pedSafetyPts = 0f;
        qualLifePts = 0f;

        floodDesc = "";
        pedSafetyDesc = "";
        qualLifeDesc = "";
}

    public void printScore()
    {
        Debug.Log("Points: " + pedSafetyPts + ", " + floodPts + "," + qualLifePts);
    }

    public int getCombinedScore()
    {
        return (int)(floodPts + pedSafetyPts + qualLifePts);
    }
}
