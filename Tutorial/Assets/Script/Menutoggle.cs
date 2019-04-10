using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menutoggle : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OtherUI;
    public GameObject Player;
    PlayerController Controller;

    public void OpenMenu()
    {
        Controller = Player.GetComponent<PlayerController>();
        Controller.target = Controller.transform.position;
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            bool OtherActive = OtherUI.activeSelf;

            OtherUI.SetActive(!OtherActive);
            Panel.SetActive(!isActive);
        }
    }

}
