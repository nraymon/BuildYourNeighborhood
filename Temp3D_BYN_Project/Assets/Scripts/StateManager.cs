using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // This class manages wether a draggable cube should be spawned.

    bool spawn = true;

    // This stack will keep track of the moves that have been made
    Stack<MoveProperties> moves = new Stack<MoveProperties>();
    // move will be used when the player wishes to undo their move; it will become the move popped off the stack
    MoveProperties move;

    private void Update()
    {

    }

    // allows for adding an element to a data structure without changed other code
    public void AddElement(MoveProperties move)
    {
        moves.Push(move);
    }

    public void Undo()
    {
        move = moves.Pop();
        move.UndoMove();
        Debug.Log(move.objPos);
        Debug.Log(move.replacementObj.name);
        Debug.Log(move.gameObj.name);
    }

    public bool GetSpawn()
    {
        return spawn;
    }

    public void SetSpawn(bool x)
    {
        spawn = x;
    }
}
