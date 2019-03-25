using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, InnventoryItem
{
    public string ItemName;
    public Sprite ItemImage;

    public string Name
    {
        get
        {
            Debug.Log("yayyy");
            return ItemName;
        }
    }

    public Sprite Image
    {
        get
        {
            return ItemImage;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
