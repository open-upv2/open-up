using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObj : MonoBehaviour
{
    public GameObject NextObj;
    public PlayerController Player;
    public string ItemToUse;
    public Cursor cursor;

    private void OnMouseDown()
    {
        if(ItemToUse == "")
        {
            if(NextObj != null)
            NextObj.SetActive(true);
            Destroy(gameObject);
        }
        else
        {
            if(Player.Hold == true && Player.Innventory[Player.SelectItem].ItemName == ItemToUse)
            {
                Player.Innventory.Remove(Player.Innventory[Player.SelectItem]);
                Player.InvenSize--;
                cursor.GetComponent<Image>().sprite = Player.Blank;
                if (NextObj != null)
                    NextObj.SetActive(true);
                Destroy(gameObject);
            }
        }

    }
}
