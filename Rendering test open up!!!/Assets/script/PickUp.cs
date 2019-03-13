using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject ObjectPick;

    void OnMouseDown()
    {
        //if (require == "")
        //{
        ObjectPick.SetActive(false);
        Debug.Log("pick helmet");
        //}
        //check if have require item or not

    }

}