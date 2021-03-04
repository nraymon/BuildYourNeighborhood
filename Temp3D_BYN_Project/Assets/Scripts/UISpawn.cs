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

    int num;

    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("GameManager").GetComponent<StateManager>();
        tVal = GameObject.Find("GameManager").GetComponent<TileValues>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //WIP spawn tiles from UI
        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.wetlands)
        {
            //this.gameObject.SetActive(false);
            Vector3 pos = new Vector3(-4.42f, 0.25f, -6.41f); //Camera.main.ScreenToWorldPoint(Input.mousePosition); //new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Debug.Log(pos);
            temp = Instantiate(tVal.GetWet(), pos, Quaternion.identity);
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.bioswale)
        {
            temp = Instantiate(tVal.GetBio());
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.house)
        {
            temp = Instantiate(tVal.GetHouse());
        }

        if (this.gameObject.GetComponent<UISpawn>().tileType == TileValues.TileType.road)
        {
            temp = Instantiate(tVal.GetRoad());
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
