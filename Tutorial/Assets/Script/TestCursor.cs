using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCursor : MonoBehaviour
{
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
