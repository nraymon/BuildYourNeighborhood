﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnDraggable : MonoBehaviour
{

    public GameObject spawnObj;
    GameObject temp;

    public TileValues.TileType tileType;

    int num;

    LocateMouse click;

    StateManager state;

    Ray mouseRay;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        click = GameObject.Find("GameManager").GetComponent<LocateMouse>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            mouseRay = click.GenerateMouseRay();
            RaycastHit hit;

            // if the ray cast hits this object and spawning is true, then a draggable object
            // is instantiated, has its name changed and spawn will now be false.
            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Draggable")) && state.GetSpawn())
            {
<<<<<<< Updated upstream
                temp = Instantiate(spawnObj);
=======

                if (hit.collider.name == "RoadSpawner" || hit.collider.name.Substring(0, 4) == "Road")
                {
                    temp = Instantiate(tVal.GetRoad());

                    if (hit.collider.GetComponent<SpawnDraggable>().ephemeral)
                    {
                        state.addThing(hit.collider.GetComponent<SpawnDraggable>().gridObj);
                        state.Undo(hit.collider.GetComponent<SpawnDraggable>().gridObj.name);
                        hit.collider.GetComponent<SpawnDraggable>().gridObj.SetActive(true);
                        StartCoroutine(hold(hit));
                    }
                }
                if (hit.collider.name == "HouseSpawner" || hit.collider.name.Substring(0, 5) == "House")
                {
                    temp = Instantiate(tVal.GetHouse());

                    if (hit.collider.GetComponent<SpawnDraggable>().ephemeral)
                    {
                        state.addThing(hit.collider.GetComponent<SpawnDraggable>().gridObj);
                        state.Undo(hit.collider.GetComponent<SpawnDraggable>().gridObj.name);
                        hit.collider.GetComponent<SpawnDraggable>().gridObj.SetActive(true);
                        StartCoroutine(hold(hit));
                    }
                }
                if (hit.collider.name == "WetSpawner" || hit.collider.name.Substring(0, 7) == "Wetland")
                {
                    temp = Instantiate(tVal.GetWet());

                    if (hit.collider.GetComponent<SpawnDraggable>().ephemeral)
                    {
                        state.addThing(hit.collider.GetComponent<SpawnDraggable>().gridObj);
                        state.Undo(hit.collider.GetComponent<SpawnDraggable>().gridObj.name);
                        hit.collider.GetComponent<SpawnDraggable>().gridObj.SetActive(true);
                        StartCoroutine(hold(hit));
                    }
                }
                if (hit.collider.name == "BioSpawner" || hit.collider.name.Substring(0, 8) == "Bioswale")
                {
                    temp = Instantiate(tVal.GetBio());

                    if (hit.collider.GetComponent<SpawnDraggable>().ephemeral)
                    {
                        state.addThing(hit.collider.GetComponent<SpawnDraggable>().gridObj);
                        state.Undo(hit.collider.GetComponent<SpawnDraggable>().gridObj.name);
                        hit.collider.GetComponent<SpawnDraggable>().gridObj.SetActive(true);
                        StartCoroutine(hold(hit));
                    }
                }

                //temp = Instantiate(this.spawnObj);
>>>>>>> Stashed changes
                temp.name = temp.name + num;
                state.SetSpawn(false);
                num++;

                //TileValues tileValues = GameObject.Find("GameManager").GetComponent<TileValues>();
                //tileValues.name = "Road Tile " + num;
                //tileValues.type = "Road";
                //tileValues.beauty = 1.5f;
                //tileValues.temperature = 2.0f;

<<<<<<< Updated upstream
                tileValues.AssignValues(num, tileType);
=======
                //tileValues.AssignValues(num, this.gameObject.GetComponent<SpawnDraggable>().tileType); // this line seems to cause tiles to default to "road" upon SnapBack
>>>>>>> Stashed changes
            }
        }

            
    }
}
