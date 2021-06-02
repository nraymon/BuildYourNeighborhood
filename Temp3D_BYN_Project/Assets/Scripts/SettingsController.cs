using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    public GameObject Settings;
    public Button OpenSettingsButton;
    public Button CloseSettingsButton;

    // Start is called before the first frame update
    void Start()
    {
        OpenSettingsButton.onClick.AddListener(OpenSettings);
        CloseSettingsButton.onClick.AddListener(CloseSettings);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenSettings()
    {
        Settings.SetActive(true);
    }

    void CloseSettings()
    {
        Settings.SetActive(false);
    }
}
