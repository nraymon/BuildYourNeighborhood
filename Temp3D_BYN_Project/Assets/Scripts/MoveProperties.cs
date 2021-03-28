using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProperties : MonoBehaviour
{


    // This will be the game object being placed
    public GameObject gameObj;
    // This is the object the placed tile will be replaced with
    public GameObject replacementObj;

    // This is used to swap the tiles at the correct position (might not acutally need this? not currently using)
    public Transform objPos;

    public void UndoMove()
    {
        Destroy(gameObj);
        replacementObj.SetActive(true);
    }

}
