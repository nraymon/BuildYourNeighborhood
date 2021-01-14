using System;
using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class tester : MonoBehaviour
{

    public Transform obj;
    System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                //Debug.Log(hit.transform.GetComponent<GridGenerator>().prefabList[0].name);
                int num = rand.Next(0, 10);
                Debug.Log(num);
                Destroy(hit.transform.gameObject);
                Instantiate(obj.GetComponent<GridGenerator>().prefabList[num], hit.transform.position, Quaternion.Euler(Vector3.right * 90));
            }
        }
    }
}
