using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnDraggable : MonoBehaviour
{

    public GameObject spawnObj;
    public GameObject gridObj;
    GameObject temp;

    public TileValues.TileType tileType;

    TileValues tVal;

    int num;

    LocateMouse click;

    StateManager state;

    // eph == true: tile can be grabbed from grid. eph == false: permanent spawner
    public bool ephemeral;

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

                if (hit.collider.name == "RoadSpawner" || hit.collider.name.Substring(0, 4) == "Road")
                {
                    temp = Instantiate(tVal.GetRoad());

                    if (hit.collider.GetComponent<SpawnDraggable>().ephemeral)
                    {
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
                        state.Undo(hit.collider.GetComponent<SpawnDraggable>().gridObj.name);
                        hit.collider.GetComponent<SpawnDraggable>().gridObj.SetActive(true);
                        StartCoroutine(hold(hit));
                    }
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

    IEnumerator hold(RaycastHit hit)
    {
        yield return new WaitForSecondsRealtime(.01f);
        Destroy(hit.collider.gameObject);
    }

    public void setGridObj(GameObject gridObj)
    {
        this.gridObj = gridObj;
    }
}
