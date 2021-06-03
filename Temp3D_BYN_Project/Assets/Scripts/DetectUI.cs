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
        //if (this.name == "Settings")
        //{
        //    this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * .5f);
        //    this.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * .75f);
        //}

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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.name == "Trash")
        {
            state.SetTrash(false);
        }
    }
}
