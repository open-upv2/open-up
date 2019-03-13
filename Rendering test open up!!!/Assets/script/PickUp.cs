using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject ObjectPick;
    public GameObject InvenObject;

    void OnMouseDown()
    {
        //if (require == "")
        //{
        ObjectPick.SetActive(false);
        Debug.Log("pick helmet");
        InvenObject.SetActive(true);
        //}
        //check if have require item or not
    }

}