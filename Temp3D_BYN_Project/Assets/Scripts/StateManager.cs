using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // This class manages wether a draggable cube should be spawned.

    bool spawn = true;

    //public Stack<MoveProperties> moves = new Stack<MoveProperties>();
    //public MoveProperties[] moves;
    public List<MoveProperties> moves = new List<MoveProperties>();
    MoveProperties move;

    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //moves = ;
        //GameObject obj = this.gameObject;
        //Vector3 pos = this.gameObject.transform.position;
        //MoveProperties prop = new MoveProperties();
        //prop.GameObj = obj;
        //prop.ObjPos = pos;
        //moves.Push(prop);
        //Debug.Log(moves.Pop().ObjPos);
        //move = GameObject.Find("GameManager").GetComponent<MoveProperties>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(moves[counter]);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {

            //while (moves.Count != 0)
            //{
            //    move = moves.Pop();
            //    Debug.Log(move.objPos);
            //    Debug.Log(move.replacementObj.name);
            //}
            //move = moves.Pop();
            //move.UndoMove();
            move = moves[moves.Count - 1];
            move.UndoMove();
            Debug.Log(move.objPos);
            Debug.Log(move.replacementObj.name);
            moves.RemoveAt(moves.Count - 1);
            //Debug.Log(move.gameObj.name);
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //move = moves.Peek();
            //Debug.Log(move.gameObj.name);
            Debug.Log(move.objPos);
            Debug.Log(move.replacementObj.name);
        }
    }

    public void AddElement(MoveProperties move)
    {
        //moves.Push(move);
        moves.Add(move);
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
