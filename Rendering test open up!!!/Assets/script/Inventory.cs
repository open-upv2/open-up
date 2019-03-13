using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    float tmp;
    public GameObject menu;

    // Start is called before the first frame update
    public void OpenMenu()
    {
        if (menu.transform.position.x < 0)
        {
            tmp = menu.transform.position.x;
            menu.transform.Translate(-(menu.transform.position.x), 0, 0);
        }
        else if(menu.transform.position.x == 0)
        {
            menu.transform.Translate(tmp, 0, 0);
        }
    }

    public void Roll(float pos)
    {
      
    }
}
