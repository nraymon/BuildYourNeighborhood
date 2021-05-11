using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // This class manages wether a draggable cube should be spawned.

    bool spawn = true;

    bool trash = false;

    // This stack will keep track of the moves that have been made
    Hashtable snapBack = new Hashtable();

    Stack<GameObject> back = new Stack<GameObject>();
    // move will be used when the player wishes to undo their move; it will become the move popped off the stack
    MoveProperties move;

    public float[,] gridPositions;
    public TileValues.TileType[,] gridTiles;

    public Scoring scoreCalculator;

    public 

    void Start()
    {
        gridPositions = new float[5, 5] { { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f } };
        
        // initiate grid with empty tile values
        gridTiles = new TileValues.TileType[5, 5];
        TileValues noneTileValues = new TileValues();
        noneTileValues.AssignValues(0, TileValues.TileType.none);
        for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                gridTiles[j, i] = TileValues.TileType.none;
            }
        }
        // scoring class used for calculating score and block interaction
        scoreCalculator = new Scoring();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CalcScore(gridTiles);

            foreach (DictionaryEntry d in snapBack)
                Debug.Log("Key: " + d.Key.ToString() + ", Value: " + d.Value.ToString());
        }
    }

    // allows for adding an element to a data structure without changed other code
    public void AddElement(MoveProperties move, string placement, TileValues.TileType tileValues)
    {
        Debug.Log("AddElement TileValues: ");
        //tileValues.PrintValues();
        //moves.Push(move);
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        //float score = tileValues.beauty;

        //Debug.Log("Temp: " + score + "\n" + "col: " + col + "\n" + "row: " + row + "\n");

        //gridPositions[col, row] = score;

        // store current tile's values in its corresponding location on the grid 
        gridTiles[col, row] = tileValues;
    }

    public void snap(string gridSpot)
    {
        snapBack.Add(gridSpot, gridSpot);
    }

    public void addThing(GameObject gridSpot)
    {
        back.Push(gridSpot);
        Debug.Log("LMAOOOOOO: " + gridSpot.name);
    }

    public GameObject backThing()
    {
        return back.Pop();
    }

    public bool test()
    {
        return back.Count == 0;
    }

    //public void Undo()
    //{
    //    move = moves.Pop();
    //    move.UndoMove();
    //    Debug.Log(move.objPos);
    //    Debug.Log(move.replacementObj.name);
    //    Debug.Log(move.gameObj.name);
    //}

    public void Undo(string placement)
    {
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        gridPositions[col, row] = 0f;

        TileValues tileValues = new TileValues();
        tileValues.AssignValues(0, TileValues.TileType.none);
        gridTiles[col, row] = tileValues.type;

        Debug.Log("gone");
    }

    public bool GetSpawn()
    {
        return spawn;
    }

    public void SetSpawn(bool x)
    {
        spawn = x;
    }

    public bool GetTrash()
    {
        return trash;
    }

    public void SetTrash(bool x)
    {
        trash = x;
    }


    public void CalcScore(TileValues.TileType[,] gridTiles)
    {
        Scoreholder totalScores = scoreCalculator.GetScore(gridTiles);
        totalScores.printScore();
        
        /*for (int i=0; i<5; i++)
        {
            for (int j=0; j<5; j++)
            {
                // if there's no tile in the current grid location, skip it
                if (gridTiles[j,i] == null)
                {
                    Debug.Log(j + "," + i + ": null");
                }
                else
                {
                    // if the tile is on the edge 
                    Debug.Log(j + "," + i + ": " + gridTiles[j, i].beauty);
                }
            }
        }*/
    }
}
