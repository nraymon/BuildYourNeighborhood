using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnDraggable : MonoBehaviour
{

    public GameObject spawnObj;
    GameObject temp;

    public TileValues.TileType tileType;

    TileValues tVal;

    int num;

    LocateMouse click;

    StateManager state;

    Ray mouseRay;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        click = GameObject.Find("GameManager").GetComponent<LocateMouse>();
        tVal = GameObject.Find("GameManager").GetComponent<TileValues>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (this.tileType == TileValues.TileType.house)
        //{
        //    Debug.Log(this.name);
        //    Debug.Log(this.tileType);
        //}

        if (Input.GetMouseButton(0))
        {
            mouseRay = click.GenerateMouseRay();
            RaycastHit hit;

            // if the ray cast hits this object and spawning is true, then a draggable object
            // is instantiated, has its name changed and spawn will now be false.
            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Draggable")) && state.GetSpawn())
            {
                if (hit.collider.name == "RoadSpawner")
                {
                    temp = Instantiate(tVal.GetRoad());
                }
                if (hit.collider.name == "HouseSpawner")
                {
                    temp = Instantiate(tVal.GetHouse());
                }
                if (hit.collider.name == "WetSpawner")
                {
                    temp = Instantiate(tVal.GetWet());
                }
                if (hit.collider.name == "BioSpawner")
                {
                    temp = Instantiate(tVal.GetBio());
                }

                //temp = Instantiate(this.spawnObj);
                temp.name = temp.name + num;
                state.SetSpawn(false);
                num++;

                TileValues tileValues = GameObject.Find("GameManager").GetComponent<TileValues>();
                //tileValues.name = "Road Tile " + num;
                //tileValues.type = "Road";
                //tileValues.beauty = 1.5f;
                //tileValues.temperature = 2.0f;

                tileValues.AssignValues(num, tileType);
            }
        }

            
    }
}
