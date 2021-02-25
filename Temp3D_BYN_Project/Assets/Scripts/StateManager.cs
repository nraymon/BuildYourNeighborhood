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
    Stack<MoveProperties> moves = new Stack<MoveProperties>();
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
        }
    }

    // allows for adding an element to a data structure without changed other code
    public void AddElement(MoveProperties move, string placement, float score)
    {
        moves.Push(move);
        int col = (int)Char.GetNumericValue(placement[0]);
        int row = (int)Char.GetNumericValue(placement[2]);

        Debug.Log("Temp: " + score + "\n" + "col: " + col + "\n" + "row: " + row + "\n");

        gridPositions[col, row] = score;
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
