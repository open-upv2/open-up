using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    public GameObject player;

    //public InnventoryItem itemSelect;
   public void OnItemClicked()
    {

        ItemDragHendler dragHandler = gameObject.transform.Find("Item").GetComponent<ItemDragHendler>();

        if(dragHandler.Item != null)
        {
            InnventoryItem item = dragHandler.Item;


            if (item != null)
            {
                Debug.Log(item.Name);
            }
            else
            {
                Debug.Log("hiiiii");
            }
        }
        else
        {
            Debug.Log("nooooo");
        }




        //item.OnUse();
    }
}
