﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{ 

    // Will become the draggable layer object
    GameObject obj;
    // Will become a quad generated by the grid
    public GameObject gridObj;

    // need an object to use the generate ray function
    LocateMouse click;

    // need an object to change the color of a game object
    ObjColorShading color;

    //Plane will be used to better determine the draggable movement of a rotated camera
    Plane objPlane;

    // Is shot out to hit a draggable layer object
    Ray mouseRay;
    // Is shout out to hit a grid layer object
    Ray mouseRay2;

    // Used to determine if a new draggable object should be spawned
    StateManager state;

    // allows the script to push a move onto the moves stack in StateManager
    MoveProperties move;

    // State, click and color all need to be initialized with getComponent for unity to be pleased
    private void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        click = GameObject.Find("GameManager").GetComponent<LocateMouse>();
        color = GameObject.Find("GameManager").GetComponent<ObjColorShading>();

        // for now this needs to be new for the other elements in the moves stack to be unique
        move = new MoveProperties();
    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            mouseRay = click.GenerateMouseRay();
            mouseRay2 = click.GenerateMouseRay();
            RaycastHit hit;

            // When left click is used, it generates a ray. The if statement determines if that ray 
            // falls in line with a draggable layer object. If this is true, the obj object is initialized and
            // the plane is generated.
            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Draggable")))
            {
                obj = hit.transform.gameObject;
                objPlane = new Plane(Camera.main.transform.forward * -1, obj.transform.position);

                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDist;
                objPlane.Raycast(mRay, out rayDist);
            }

            // This checks if the second ray will hit a GridMap object, if true then the gridObj
            // object will be initialized
            if (Physics.Raycast(mouseRay2.origin, mouseRay2.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("GridMap")))
            {
                gridObj = hit.transform.gameObject;
            }

            // checks to see if the second ray cast is not hitting anything but we have a drabble object.
            // If this is true, gridObj should return to null, and the color of the draggable object
            // turns transparent and red, indicating it cannot be placed at the current location
            else if (!Physics.Raycast(mouseRay2.origin, mouseRay2.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("GridMap")) && obj)
            {
                gridObj = null;
                this.GetComponent<Renderer>().material.SetColor("_Color", color.ChangeObjShading(obj, 100, 0, 0, 100));
            }

        } 

        // If left click is being held and the player is dragging an object,
        // plane will have a ray cast to it in order for the drag to look
        // natural at any perspective and angle. The Y position of the draggable object
        // is clamped so that the object is alway above the grid.
        if (Input.GetMouseButton(0) && obj)
        {
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDist;
            this.GetComponent<Renderer>().material.SetColor("_Color", color.ChangeObjShading(obj, 100, 0, 0, 100));
            if (objPlane.Raycast(mRay, out rayDist))
            {
                this.transform.position = mRay.GetPoint(rayDist);
                var pos = this.transform.position;
                pos.y = Mathf.Clamp(this.transform.position.y, 1.2f, 5f);
                this.transform.position = pos;
            }
        }

        // If both the draggable object and gridObj have a ray cast hitting them,
        // the color of the draggable object turns green, indicating this is a valid
        // location to place it in the grid.
        if (Input.GetMouseButton(0) && obj && gridObj)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", color.ChangeObjShading(obj, 0, 100, 0, 100));
        }

        // If left click is no longer being held and both objects are initialized,
        // the grid object will be destroyed (will prob need to change this?), the 
        // draggable object takes the position of the grid object, moves it up a bit, 
        // changes its layer so it can't be dragged again, and gets rid of the draggable
        // script. SetSpawn is also set to true so a new object can be grabbed from the
        // "pile." Both object are set to null and the color is returned to drag object.
        if (Input.GetMouseButtonUp(0) && obj && gridObj)
        {
            // setting up the move element to be placed on the moves Stack in StateManager
            move.gameObj = obj;
            move.objPos = obj.transform;
            move.replacementObj = gridObj;
            state.AddElement(move, gridObj.name);

            // no more destroying the gridObj, this allows for undoing a move
            gridObj.SetActive(false);

            // abstract this block in a function?
            obj.transform.position = gridObj.transform.position;
            obj.transform.position += new Vector3(0, .5f, 0);
            obj.layer = 0;
            Destroy(GetComponent<Draggable>());
            state.SetSpawn(true);
            gridObj = null;

            this.GetComponent<Renderer>().material.SetColor("_Color", color.ChangeObjShading(obj, 255, 255, 255, 255));
            obj = null;

            TileValues tileValues = GameObject.Find("GameManager").GetComponent<TileValues>();
            tileValues.PrintValues();
        }

        // If the mouse button is let go and we only have the draggable object,
        // then object stays where it was placed and returns to its original color.
        if (Input.GetMouseButtonUp(0) && obj)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", color.ChangeObjShading(obj, 255, 255, 255, 255));
            obj = null;
        }
    }
}
