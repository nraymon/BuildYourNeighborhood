using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjColorShading : MonoBehaviour
{
    public Color32 ChangeObjShading(GameObject obj, int r, int g, int b, int a)
    {
        Color32 col = obj.GetComponent<Renderer>().material.GetColor("_Color");
        col.r = (byte)r;
        col.g = (byte)g;
        col.b = (byte)b;
        col.a = (byte)a;

        return col;
    }
}
