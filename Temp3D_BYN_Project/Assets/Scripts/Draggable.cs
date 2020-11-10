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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = GenerateMouseRay();
            RaycastHit hit;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
            {
                obj = hit.transform.gameObject;
                //mo = hit.transform.position - hit.point;
            }
        } else if (Input.GetMouseButton(0) && obj)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Color32 col = this.GetComponent<Renderer>().material.GetColor("_Color");
            col.a = 100;
            col.r = 100;
            col.g = 0;
            col.b = 0;
            this.GetComponent<Renderer>().material.SetColor("_Color", col);
            this.transform.position = new Vector3(newPos.x + mo.x, newPos.y + mo.y, this.transform.position.z);
        } else if (Input.GetMouseButtonUp(0) && obj)
        {
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
