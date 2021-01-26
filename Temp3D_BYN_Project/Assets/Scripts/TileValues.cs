using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileValues : MonoBehaviour
{
    public string name;
    public TileType type;
    public float beauty;
    public float temperature;

    //enum to allow tiles to distinguish their tile type
    public enum TileType
    {
        road, house, bioswale, wetlands
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignValues(int num, TileType tileType)
    {
        //TileValues tileValues = spawnedTile.GetComponent<TileValues>();
        //tileValues.name = "Road Tile " + num;
        //tileValues.type = "Road";
        //tileValues.beauty = 1.5f;
        //tileValues.temperature = 2.0f;
        switch (tileType)
        {
            case TileType.road:
                name = "Road Tile " + num;
                type = TileType.road;
                beauty = 1.5f;
                temperature = 2.0f;
                break;
            case TileType.house:
                name = "House " + num;
                type = TileType.house;
                beauty = 4f;
                temperature = 1f;
                break;
            case TileType.bioswale:
                name = "Bioswale " + num;
                type = TileType.bioswale;
                beauty = 2f;
                temperature = 0.5f;
                break;
            case TileType.wetlands:
                name = "Wetlands " + num;
                type = TileType.wetlands;
                beauty = 3f;
                temperature = 0.5f;
                break;
            default:
                break;
        }
        {

        }


    }


    public void PrintValues()
    {
        Debug.Log("Name: " + name + ", Type: " + type + ", Beauty: " + beauty + ", Temp: " + temperature + "\n");
    }
}
