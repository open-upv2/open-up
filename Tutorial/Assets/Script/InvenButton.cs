using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenButton : MonoBehaviour
{
    public int slotNum;
    public GameObject player;

    public void Update()
    {
        PlayerController PlayerControl = player.GetComponent<PlayerController>();
    }

    public void Selected()
    {
        PlayerController PlayerControl = player.GetComponent<PlayerController>();
        if(PlayerControl.Inventory.Count >= slotNum /*&& PlayerControl.Inventory[slotNum] != null*/)
        {
            Debug.Log(PlayerControl.Inventory[slotNum]);
        }

    }
}
