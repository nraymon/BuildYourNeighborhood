using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // Start is called before the first frame update

    bool spawn = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public bool GetSpawn()
    {
        return spawn;
    }

    public void SetSpawn(bool x)
    {
        spawn = x;
    }
}
