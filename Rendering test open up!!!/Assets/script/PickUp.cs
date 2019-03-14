using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    public GameObject ObjectPick;
    public GameObject InvenObject;

    static int InvenCount = 0;

    void OnMouseDown()
    {
        //if (require == "")
        //{
        ObjectPick.SetActive(false);
        //Debug.Log("pick helmet");
        InvenObject.SetActive(true);
        InvenCount++;
        if(InvenCount >= 1)
        {
            InvenObject.transform.Translate((InvenCount-1) * 1, 0, 0);
        }
        Debug.Log(InvenCount);
        //}
        //check if have require item or not
    }

}