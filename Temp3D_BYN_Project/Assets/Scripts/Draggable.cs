using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    //    public void OnBeginDrag(PointerEventData eventData)
    //    {
    //        Debug.Log("begin drag");
    //    }

    GameObject obj;
    GameObject gridObj;

    Plane objPlane;

    Ray mouseRay;
    Ray mouseRay2;

    Vector3 mo;

    Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }

    //private void FixedUpdate()
    //{
    //    Debug.Log("Mouse ray orign: " + mouseRay.origin);
    //    Debug.Log("Mouse ray dir: " + mouseRay.direction);
    //    Debug.Log("Mouse ray orign: " + mouseRay2.origin);
    //    Debug.Log("Mouse ray2 dir: " + mouseRay2.direction);
    //}

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            mouseRay = GenerateMouseRay();
            mouseRay2 = GenerateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("Draggable")))
            {
                obj = hit.transform.gameObject;
                objPlane = new Plane(Camera.main.transform.forward * -1, obj.transform.position);

                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float rayDist;
                objPlane.Raycast(mRay, out rayDist);
                mo = obj.transform.position - mRay.GetPoint(rayDist);
            }

            if (Physics.Raycast(mouseRay2.origin, mouseRay2.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("GridMap")))
            {
                gridObj = hit.transform.gameObject;
            }else if (!Physics.Raycast(mouseRay2.origin, mouseRay2.direction, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("GridMap")) && obj)
            {
                gridObj = null;
                Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
                col.a = 100;
                col.r = 100;
                col.g = 0;
                col.b = 0;
                this.GetComponent<Renderer>().material.SetColor("_Color", col);
            }
        } if (Input.GetMouseButton(0) && obj)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDist;
            //Camera.main.wo
            Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
            col.a = 100;
            col.r = 100;
            col.g = 0;
            col.b = 0;
            this.GetComponent<Renderer>().material.SetColor("_Color", col);
            if (objPlane.Raycast(mRay, out rayDist))
            {
                this.transform.position = mRay.GetPoint(rayDist);// + mo; //new Vector3(newPos.x, newPos.y, this.transform.position.z);
                var pos = this.transform.position;
                pos.y = Mathf.Clamp(this.transform.position.y, 1.2f, 5f);
                this.transform.position = pos;
            }
        }
        if (Input.GetMouseButton(0) && obj && gridObj)
        {
            //Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
            col.a = 100;
            col.r = 0;
            col.g = 100;
            col.b = 0;
            this.GetComponent<Renderer>().material.SetColor("_Color", col);
            //this.transform.position = new Vector3(newPos.x + mo.x, newPos.y + mo.y, this.transform.position.z);
        }
        if (Input.GetMouseButtonUp(0) && obj && gridObj)
        {
            gridObj.GetComponent<Renderer>().enabled = false;
            //obj.transform.rotation = gridObj.transform.rotation;
            obj.transform.position = gridObj.transform.position;

            //obj.transform.Translate(gridObj.transform.position);
            obj = null;
            gridObj = null;
            Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
            col.a = 255;
            col.r = 255;
            col.g = 255;
            col.b = 255;
            this.GetComponent<Renderer>().material.SetColor("_Color", col);
        }
        if (Input.GetMouseButtonUp(0) && obj)
        {
            Debug.Log("not same");
            obj = null;
            Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
            col.a = 255;
            col.r = 255;
            col.g = 255;
            col.b = 255;
            this.GetComponent<Renderer>().material.SetColor("_Color", col);
        }
    }

    //public void OnMouseDrag()
    //{
    //    Debug.Log("dragging");
    //    Ray mouseRay = GenerateMouseRay();
    //    RaycastHit hit;

    //    Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
    //    col.a = 50;
    //    this.GetComponent<Renderer>().material.SetColor("_Color", col);
    //    this.transform.position = new Vector3(newPos.x - mo.x, newPos.y - mo.y, this.transform.position.z);

    //    //if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
    //    //{
    //    //    obj = hit.transform.gameObject;
    //    //}
    //}

    //public void Update()
    //{
    //    OnMouseDrag();
    //}
}
