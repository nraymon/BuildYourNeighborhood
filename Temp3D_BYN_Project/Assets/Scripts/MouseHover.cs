using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
     {    
        gameObject.GetComponent<Renderer>().material.color = Color.black;
     }

    void OnMouseEnter(){
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnMouseExit(){
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
