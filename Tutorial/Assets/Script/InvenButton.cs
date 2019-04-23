using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenButton : MonoBehaviour
{
    public int slotNum;
    public GameObject player;
    public Image SlotImage;
    PlayerController PlayerControl;
    public GameObject InvenPanel;
    public Cursor cursor;

    public void Start()
    {
        PlayerControl = player.GetComponent<PlayerController>();
    }

    public void Update()
    {
        if (PlayerControl.Innventory.Count > slotNum && PlayerControl.Innventory[slotNum] != null)
        {
            SlotImage.sprite = PlayerControl.Innventory[slotNum].ItemImage;
        }
        else
        {
            SlotImage.sprite = PlayerControl.Blank;
        }
    }

    public void Selected()
    {
        Debug.Log("Select");
        if(PlayerControl.Innventory.Count > slotNum && PlayerControl.Innventory[slotNum] != null)
        {
            PlayerControl.SelectItem = slotNum;
            PlayerControl.Hold = true;
            Debug.Log(PlayerControl.Innventory[PlayerControl.SelectItem].ItemName);
            Debug.Log(PlayerControl.SelectItem);
            InvenPanel.SetActive(false);
            cursor.GetComponent<Image>().sprite = PlayerControl.Innventory[PlayerControl.SelectItem].ItemImage;
            PlayerControl.stayStill = false;
        }
    }
}
