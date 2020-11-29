using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProperties : MonoBehaviour
{

    public GameObject gameObj;
    public GameObject replacementObj;

    public Transform objPos;

    //public MoveProperties(GameObject obj, Vector3 pos)
    //{
    //    GameObj = obj;
    //    ObjPos = pos;
    //}

    public void UndoMove()
    {
        Destroy(gameObj);
        replacementObj.SetActive(true);
        //replacementObj = null;
    }

}
