using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnDraggable : MonoBehaviour
{

    public GameObject spawnObj;
    GameObject temp;

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
                temp = Instantiate(spawnObj);
                temp.name = temp.name + num;
                state.SetSpawn(false);
                num++;
            }
        }

            
    }
}
