/***************************************************
Allows UI panels to be dragged and moved around the game screen
using the mouse (or one finger on mobile) to control movement.
Tutorial referenced: https://youtu.be/Mb2oua3FjZg 
***************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragPanel : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;   // used select & move the whole panel instead of just the top banner
    [SerializeField] private Canvas canvas;                     // reference the in-game UI canvas


    /*// make window transparent on begin drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // move the panel location! Scale by the resolution of the canvas 
    }

/*    // make window opaque on end drag
    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }*/
}
