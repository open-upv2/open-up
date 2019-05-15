using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearFlashlight : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    GameObject clue;

    // Start is called before the first frame update
    private void OnMouseOver()
    {
        if(player.Hold == true && player.Innventory[player.SelectItem].ItemName == "flashlight")
        {
            clue.SetActive(true);
        }
        else
        {
            clue.SetActive(false);
        }
    }

    private void OnMouseExit()
    {
        clue.SetActive(false);
    }
}
