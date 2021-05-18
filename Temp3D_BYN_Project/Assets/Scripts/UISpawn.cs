using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISpawn : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{

    TileValues tVal;
    GameObject temp;
    StateManager state;

    public TileValues.TileType tileType;
    public Canvas test;
    Vector3 spawnPoint;

    int num;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        tVal = GameObject.Find("GameManager").GetComponent<TileValues>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.wetlands && state.GetSpawn())
        {
            //Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            // Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log("screen to ray: " + Camera.main.ScreenPointToRay(Input.mousePosition).ToString());
            //Debug.Log("screen to viewport: " + Camera.main.ScreenToViewportPoint(Input.mousePosition).ToString());
            //Debug.Log("screen to world: " + Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
            //Debug.Log("viewport to ray: " + Camera.main.ViewportPointToRay(Input.mousePosition).ToString());
            //Debug.Log("viewport to screen: " + Camera.main.ViewportToScreenPoint(Input.mousePosition).ToString());
            //Debug.Log("viewport to world: " + Camera.main.ViewportToWorldPoint(Input.mousePosition).ToString());
            //Debug.Log("world to screen: " + Camera.main.WorldToScreenPoint(Input.mousePosition).ToString());
            //Debug.Log("world to viewport: " + Camera.main.WorldToViewportPoint(Input.mousePosition).ToString());

            //Debug.Log("lol: " + this.transform.position);

            //Debug.Log("pos: " + pos);
            //Debug.Log(pos);
            pos.x += 5f;
            pos.y -= 2.5f;
            pos.z += 5f;

            Quaternion rot = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.x, pos);

            Vector3 newPos = rot * pos;

            Debug.Log("viewport thing: " + Camera.main.ViewportToWorldPoint(state.wetlandPos.transform.position));
            
            //rot.z -= 1;
            //Debug.Log("Wetlands pos: " + state.wetlandPos.transform.position);
            //temp = Instantiate(tVal.GetWet(), pos, tVal.GetWet().transform.rotation);
            temp = Instantiate(tVal.GetWet(), state.mainSpawn.transform.position, tVal.GetWet().transform.rotation);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.bioswale && state.GetSpawn())
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("pos: " + pos);
            pos.x += 5f;
            pos.y -= 2.5f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;

            //Debug.Log("lol: " + this.transform.position);

            Vector3 p = Camera.main.ViewportToWorldPoint(state.bioswalePos.transform.position);
            p.x = pos.x;
            p.z = pos.z;

            Debug.Log("viewport thing: " + Camera.main.ViewportToWorldPoint(state.bioswalePos.transform.position));

            //rot.y += 1;
            //Debug.Log("Bioswale pos: " + pos.ToString());
            //temp = Instantiate(tVal.GetBio(), pos, tVal.GetBio().transform.rotation);
            temp = Instantiate(tVal.GetBio(), state.mainSpawn.transform.position, tVal.GetBio().transform.rotation);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.house && state.GetSpawn())
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("pos: " + pos);
            pos.x += 5f;
            pos.y -= 2.5f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;

            Debug.Log("lol: " + this.transform.position);

            //rot.y -= 1;
            Debug.Log("House pos: " + pos.ToString());
            //temp = Instantiate(tVal.GetHouse(), pos, tVal.GetHouse().transform.rotation);
            temp = Instantiate(tVal.GetHouse(), state.mainSpawn.transform.position, tVal.GetHouse().transform.rotation);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.road && state.GetSpawn())
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("pos: " + pos);
            pos.x += 5.2f;
            pos.y -= 2.8f;
            pos.z += 5f;
            Quaternion rot = Quaternion.identity;

            Debug.Log("lol: " + this.transform.position);

            //rot.z -= 1;
            Debug.Log("Road pos: " + pos.ToString());
            //temp = Instantiate(tVal.GetRoad(), pos, tVal.GetRoad().transform.rotation);
            temp = Instantiate(tVal.GetRoad(), state.mainSpawn.transform.position, tVal.GetRoad().transform.rotation);
        }

        temp.name = temp.name + num;
        state.SetSpawn(false);

        TileValues tileValues = GameObject.Find("GameManager").GetComponent<TileValues>();
        tileValues.AssignValues(num, tileType);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.SetActive(true);
    }
}
