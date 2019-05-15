using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool select = false;
    public string Function;
    public string ItemToUse;
    public GameObject ObjAppear;
    public AudioSource InteractingSound;
    public bool destroy;
    public int DialogueTag;
    public int ExploTag;
    public bool removeInven;
    public string soundName;
    public string AniName;

    //destroy

    private void OnMouseDown()
    {
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
