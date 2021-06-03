using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreholder
{
    public TileValues.TileType tileOne;
    public TileValues.TileType tileTwo;

    public float floodPts;
    public float pedSafetyPts;
    public float qualLifePts;

    public string floodDesc;
    public string pedSafetyDesc;
    public string qualLifeDesc;

    public Scoreholder()
    {
        tileOne = TileValues.TileType.none;
        tileOne = TileValues.TileType.none;

        floodPts = 0f;
        pedSafetyPts = 0f;
        qualLifePts = 0f;

        floodDesc = "";
        pedSafetyDesc = "";
        qualLifeDesc = "";
}

    public void printScore()
    {
        Debug.Log("Points: " + pedSafetyPts + ", " + floodPts + "," + qualLifePts + ", interaction: " + tileOne.ToString() + ", " + tileTwo.ToString());
    }

    public int getCombinedScore()
    {
        return (int)(floodPts + pedSafetyPts + qualLifePts);
    }
}
