using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DetectNormUI : MonoBehaviour
{
    StateManager state;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
