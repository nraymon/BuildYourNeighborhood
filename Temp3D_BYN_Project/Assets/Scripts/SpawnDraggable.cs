using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnDraggable : MonoBehaviour
{

    public GameObject spawnObj;
    GameObject temp;

    int num;

    Draggable drag;

    StateManager state;

    Ray mouseRay;

    // Generates a ray from the near clipping field plane to the far clipping plane
    // based on mouse location in the viewport
    Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            mouseRay = GenerateMouseRay();
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
