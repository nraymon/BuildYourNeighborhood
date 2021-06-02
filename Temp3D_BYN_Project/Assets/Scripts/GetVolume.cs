using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class GetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("master", 1f);
    }
}
