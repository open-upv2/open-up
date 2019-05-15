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
    public Animator InvenBoxAni;
    bool isOpen;

    private void Start()
    {
        Controller = Player.GetComponent<PlayerController>();
        PlayerAni = Player.GetComponent<Animator>();

    }

    public void OpenMenu()
    {
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
            foreach (GameObject item in Collectable)
            {
            if(item.GetComponent<PickObj>() != null)
                item.GetComponent<PickObj>().select = false;
            }

        if(Panel != null)
        {
            if (InvenBoxAni != null)
            {
                isOpen = InvenBoxAni.GetBool("OpenInven");
                InvenBoxAni.SetBool("OpenInven", !isOpen);
                //if (!isOpen == true)
                //{
                //    Controller.stayStill = true;
                //}
                //else
                //{
                //    Controller.stayStill = false;
                //}
            }
        }
    }

}
