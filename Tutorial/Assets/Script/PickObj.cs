using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickObj : MonoBehaviour
{
    //property
    public bool destroy; //Check to destroy object after pick
    public bool pick; //recieve item or not
    public AudioClip PickingSound; //Play when pick
    public string ItemName; //Name Item to add in inventory
    public Sprite ItemImage; //Sprite Item
    public int DialogueTag; //Dialogue string Number
    public int ExploDiaTag;
    public string soundName;
    public string AniName;

    //เงื่อนไข
    public bool select = false; //Check if to pick up or not
    public string ItemToUse; //Use item to pick up
    public bool removeInven;

    //Other
    GameObject[] Collectable;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject item in Collectable)
        {
            item.GetComponent<PickObj>().select = false;
        }
        select = true;
    }

    public Texture2D cursorDefault;
    public Texture2D cursorInteract;
    public Texture2D cursorExplore;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteract, hotSpot, cursorMode);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
    }
}

public class Item
{
    public Sprite ItemImage;
    public string ItemName;
}

