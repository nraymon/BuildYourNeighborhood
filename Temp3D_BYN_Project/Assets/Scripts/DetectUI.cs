using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (this.name == "Trash")
        {
            state.SetTrash(true);
        }
        else
        {
            state.setUI(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (this.name == "Trash")
        {
            state.SetTrash(false);
        }
        else
        {
            state.setUI(false);
        }
    }
}
