using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObj : MonoBehaviour
{
    public GameObject otherGameobject;
    public PlayerController player;
    public Interact objInteract;
    public bool active;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if(active == true)
        {
            otherGameobject.SetActive(true);
            player.stayStill = true;
        }
        else 
        {
            otherGameobject.SetActive(false);
            player.stayStill = false;
            objInteract.select = false;
        }
    }

    public void SetGameOBJActive()
    {
        if (active == true)
        {
            otherGameobject.SetActive(true);
            if(player != null)
            player.stayStill = true;
        }
        else
        {
            otherGameobject.SetActive(false);
            if(objInteract != null)
            objInteract.select = false;
            if(player != null)
            player.stayStill = false;
        }
    }
}
