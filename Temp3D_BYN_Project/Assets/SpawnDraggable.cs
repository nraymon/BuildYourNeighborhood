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

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Draggable")) && state.GetSpawn())
            {
                Debug.Log(num);
                //temp = PrefabUtility.InstantiatePrefab(spawnObj);
                temp = Instantiate(spawnObj);
                temp.name = temp.name + num;
                state.SetSpawn(false);
                num++;
            }
        }

            
    }
}
