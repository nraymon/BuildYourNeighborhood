using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Save
{
    private class SaveData
    {
        public float Ped;
        public float Flood;
        public float QoL;
        public int NumBioswale;
        public int NumStreet;
        public int NumHouse;
        public int NumWetland;

        public SaveData()
        {
            Ped = 0;
            Flood = 0;
            QoL = 0;
            NumBioswale = 0;
            NumStreet = 0;
            NumHouse = 0;
            NumWetland = 0;
        }
    }

    private StateManager state;
    private Scoreholder scores;

    public void writeSave()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        scores = GameObject.Find("GameManager").GetComponent<Scoreholder>();
        SaveData saveinfo = new SaveData();
        saveinfo.Ped = scores.pedSafetyPts;
        saveinfo.Flood = scores.floodPts;
        saveinfo.QoL = scores.qualLifePts;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                TileValues.TileType tile = state.gridTiles[i, j];
                switch (tile)
                {
                    case TileValues.TileType.road:
                        saveinfo.NumStreet++;
                        break;
                    case TileValues.TileType.house:
                        saveinfo.NumHouse++;
                        break;
                    case TileValues.TileType.bioswale:
                        saveinfo.NumBioswale++;
                        break;
                    case TileValues.TileType.wetlands:
                        saveinfo.NumWetland++;
                        break;
                    case TileValues.TileType.none:
                        break;
                    default:
                        break;
                }
            }
        }

        string json = JsonUtility.ToJson(saveinfo);

        string filePath = "Saves/lastSave.json";
        if (File.Exists(filePath))
            Debug.LogWarning($"Overwriting previous data at {filePath}");

        using (StreamWriter sw = new StreamWriter(filePath))
            sw.Write(json);
    }
}
