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

    bool rotate = true;

    bool exitUI = true;

    // This stack will keep track of the moves that have been made
    Hashtable snapBack = new Hashtable();

    Stack<GameObject> back = new Stack<GameObject>();
    // move will be used when the player wishes to undo their move; it will become the move popped off the stack
    MoveProperties move;

    public float[,] gridPositions;

    void Start()
    {
        gridPositions = new float[5, 5] { { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f }, { 0f, 0f, 0f, 0f, 0f } };
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            float sum = 0;
            for (int i = 0; i < 5; i++)
            {
                int j;
                for (j = 0; j < 5; j++)
                {
                    sum += gridPositions[j, i];
                }

                Debug.Log("Row " + i + " contains " + sum + " points.");
                sum = 0;
            }

            foreach (DictionaryEntry d in snapBack)
                Debug.Log("Key: " + d.Key.ToString() + ", Value: " + d.Value.ToString());
        }
    }

    // allows for adding an element to a data structure without changed other code
    public void AddElement(MoveProperties move, string placement, float score)
    {
        //moves.Push(move);
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        Debug.Log("Temp: " + score + "\n" + "col: " + col + "\n" + "row: " + row + "\n");

        gridPositions[col, row] = score;
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

    public void rotTrue()
    {
        rotate = true;
    }

    public void rotFalse()
    {
        rotate = false;
    }

    public void exit()
    {
        exitUI = true; 
    }

    public void exitFalse()
    {
        exitUI = false;
    }

    public bool getExit()
    {
        return exitUI;
    }

    public bool getRot()
    {
        return rotate;
    }

    public void Undo(string placement)
    {
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        gridPositions[col, row] = 0f;

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
}
