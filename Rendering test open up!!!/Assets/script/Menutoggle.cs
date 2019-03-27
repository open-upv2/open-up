using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menutoggle : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OtherUI;

    public void OpenMenu()
    {
        if(Panel != null)
        {
            bool isActive = Panel.activeSelf;
            bool OtherActive = OtherUI.activeSelf;

            OtherUI.SetActive(!OtherActive);
            Panel.SetActive(!isActive);
        }
    }

}
