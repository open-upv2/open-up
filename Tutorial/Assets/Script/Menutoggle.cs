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
    Animator PlayerAni;

    public void OpenMenu()
    {
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject item in Collectable)
        {
            item.GetComponent<PickObj>().select = false;
        }
        Controller = Player.GetComponent<PlayerController>();
        Controller.target = Controller.transform.position;
        PlayerAni = Player.GetComponent<Animator>();
        if(Panel != null)
        {
            if(Panel.activeSelf == false)
            {
                Panel.SetActive(true);
                Controller.stayStill = true;
                PlayerAni.SetBool("Walk", false);
            }
            else if(Panel.activeSelf == true)
            {
                Panel.SetActive(false);
                Controller.stayStill = false;
            }
        }
    }

}
