using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    //property
    public bool destroy; //Check to destroy object after pick
    public bool pick; //recieve item or not
    public AudioClip PickingSound; //Play when pick
    public string ItemName; //Name Item to add in inventory
    public Sprite ItemImage; //Sprite Item
    public int DialogueTag; //Dialogue string Number

    //เงื่อนไข
    public bool select = false; //Check if to pick up or not
    public string ItemToUse; //Use item to pick up

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
}
