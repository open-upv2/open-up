using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    //public List<int> Password = new List<int>();

    //public Text keyPass;
    //int[] correctPass = new int[4] { 8, 8, 8, 8 };
    //int size;
    //int check;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = KeyButton.playerCode;
        //    check = 0;
        //    size = Password.Count;
        //    switch(size)
        //    {
        //        case 0 :
        //            keyPass.text = "Enter";
        //            break;
        //        case 1 :
        //            keyPass.text = " *";
        //            break;
        //        case 2 :
        //            keyPass.text = " * * ";
        //            break;
        //        case 3:
        //            keyPass.text = " * * * ";
        //            break;
        //        case 4:
        //            keyPass.text = " * * * *";
        //            for(int i = 0; i < 4; i++)
        //            {
        //                if(Password[i] == correctPass[i])
        //                {
        //                    check++;
        //                }
        //                else
        //                {
        //                    for(int j = 0; j < 4; j++)
        //                    {
        //                        Password.Remove(j);
        //                    }
        //                    break;
        //                }
        //                if(check == 4)
        //                {
        //                    keyPass.text = "Correct";
        //                }
        //            }
        //            break;
        //    }
    }
}
