using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void changeScene(string scene){
        Application.LoadLevel(scene);
    }
}
