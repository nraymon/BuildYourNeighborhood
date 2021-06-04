using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{

    public float xOffset;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 pos = this.GetComponent<RectTransform>().position;
        //Debug.Log("thing");
        //Debug.Log("width: " + gameObject.GetComponentInParent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta.x);
        //Debug.Log("height: " + gameObject.GetComponentInParent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta.y);
        //pos.x = gameObject.GetComponentInParent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta.x * 1.46f;
        //pos.y = gameObject.GetComponentInParent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta.y * 1.11f;
        //Debug.Log("pos: " + pos);
        //this.GetComponent<RectTransform>().position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.GetComponent<RectTransform>().position;
        pos.x = gameObject.GetComponentInParent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta.x * 1.46f;
        pos.y = gameObject.GetComponentInParent<RectTransform>().parent.GetComponent<RectTransform>().sizeDelta.y * 1.11f;
        this.GetComponent<RectTransform>().position = pos;
    }
}
