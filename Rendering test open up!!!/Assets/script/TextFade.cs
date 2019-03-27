using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
   // public GameObject ClarisaText;
    float timeCount = 0;

    void Start()
    {
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            timeCount = Time.time;
            if (timeCount % 8 == 0)
            {
                gameObject.SetActive(false);
            }
        }
    }



    //float timeCount = 0;

    //void Fading()
    //{
    //    timeCount = Time.time;
    //    if(timeCount % 8 == 0)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
