using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menutoggle : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OtherUI;
    public GameObject Player;
    PlayerController Controller;
    GameObject[] Collectable;

    public void OpenMenu()
    {
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject item in Collectable)
        {
            item.GetComponent<PickObj>().select = false;
        }
        Controller = Player.GetComponent<PlayerController>();
        Controller.target = Controller.transform.position;
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            bool OtherActive = OtherUI.activeSelf;
            Controller.interact = !Controller.interact;

            OtherUI.SetActive(!OtherActive);
            Panel.SetActive(!isActive);
        }
    }

}
