using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    //Must be public
    public void ChangePos(float move)
    {
        transform.position = new Vector3(move, 0f, 0f);
    }

    ////Must be public
    //public void ChangeFtoL()
    //{
    //    transform.position = new Vector3(38.82f, 0f, 0f);
    //    flag = 2;
    //}
    ////Must be public
    //public void ChangeLtoF()
    //{
    //    transform.position = new Vector3(-38.82f, 0f, 0f);
    //    flag = 0;
    //}

    ////Must be public
    //public void ChangeRtoF()
    //{
    //    transform.position = new Vector3(-19.77f, 3f, 0f);
    //    flag = 0;
    //}
   
}
