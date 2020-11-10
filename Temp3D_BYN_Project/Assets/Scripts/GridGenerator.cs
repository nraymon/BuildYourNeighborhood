using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{

    public Transform tilePrefab;
    public Vector2 gridSize;

    public Transform[] prefabList = new Transform[10];

    [Range(0, 1)]
    public float outlinePercent;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    public void GenerateGrid()
    {

        string holderName = "Generated Map";
        if (transform.FindChild(holderName))
        {
            DestroyImmediate(transform.FindChild(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-gridSize.x / 2 + 0.5f + x, 0, -gridSize.y / 2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
                newTile.localScale = Vector3.one * (1 - outlinePercent);
                newTile.parent = mapHolder;
                newTile.name = "Quad " + x.ToString() + ", " + y.ToString();
            }
        }
    }

}
