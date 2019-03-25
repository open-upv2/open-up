using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InnventoryItem
{
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(InnventoryItem item)
    {
        Item = item;
    }

    public InnventoryItem Item;
    
}

//public class Innventory : MonoBehaviour
//{
//    public bool[] isFull;
//    public GameObject[] slots;
//}
