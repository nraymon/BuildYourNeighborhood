using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(GridGenerator))]
public class MapEditor : Editor
{

    //Allows the grid to be generated without actually playing
    [System.Obsolete]
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GridGenerator map = target as GridGenerator;

        map.GenerateGrid();
    }
}
