using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MasterVolumeController : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider slider;
    public List<GameObject> sources;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("master", 1f);
        //mixer.SetFloat("master", Mathf.Log10(slider.value) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        adjustVolume(slider.value);
        for (int i = 0; i < sources.Count; i++)
        {
            sources[i].GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("master");
        }
    }

    public void adjustVolume(float vol)
    {
        PlayerPrefs.SetFloat("master", vol);
        //mixer.SetFloat("master", Mathf.Log10(slider.value) * 20);
    }
}
