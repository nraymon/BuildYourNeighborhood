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
        state.setUI(true);

        if (this.name == "Trash")
        {
            state.SetTrash(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        state.setUI(false);

        if (this.name == "Trash")
        {
            state.SetTrash(false);
        }
    }
}
