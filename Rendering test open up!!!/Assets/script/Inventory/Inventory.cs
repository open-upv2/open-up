using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 9;

    private List<InnventoryItem> mItems = new List<InnventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(InnventoryItem item)
    {
        if (mItems.Count < SLOTS)
        {
            mItems.Add(item);
            item.OnPickup();
            if (ItemAdded != null)
            {
                ItemAdded(this, new InventoryEventArgs(item));
            }
        }
    }


    //float tmp;
    public GameObject menu;
    //public GameObject[] invenItem;

    //// Start is called before the first frame update
    public void OpenMenu()
    {
        if (menu != null)
        {
            bool isActive = menu.activeSelf;

            menu.SetActive(!isActive);
        }
    }

    //public void Roll()
    //{
    //    if (menu.transform.position.x < 0)
    //    {
    //        tmp = menu.transform.position.x;
    //        menu.transform.Translate(-(menu.transform.position.x), 0, 0);
    //    }
    //    else if (menu.transform.position.x == 0)
    //    {
    //        menu.transform.Translate(tmp, 0, 0);
    //    }
    //}
}
