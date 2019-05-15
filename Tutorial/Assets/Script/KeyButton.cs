using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    [SerializeField]
    AudioSource keyPadAu;

    [SerializeField]
    GameObject Ending;

    [SerializeField]
    GameObject EndingText;

    [SerializeField]
    GameObject KeyPadOBJ;

    [SerializeField]
    GameObject ItemSelect;

    public AudioClip ButtonPress;
    public AudioClip correctPass;
    public AudioClip WrongPass;

    public KeyPad keyPad;
    public int keyNum;
    public static string correctCode = "4632";
    public static string playerCode = "";
    public static int digitCount = 0;
    public bool correct = false;

    private void Update()
    {
        if(playerCode != "" && correct == false)
        {
            if (digitCount == 4)
            {
                if (playerCode == correctCode)
                {
                    correct = true;
                    playerCode = "";
                    digitCount = 0;
                    Debug.Log("Correct Password");
                    Ending.SetActive(true);
                    EndingText.SetActive(true);
                    KeyPadOBJ.SetActive(false);
                    ItemSelect.SetActive(false);
                    keyPadAu.clip = correctPass;
                    keyPadAu.Play();

                }
                else
                {
                    Debug.Log("Wrong Password");
                    playerCode = "";
                    digitCount = 0;
                    keyPadAu.clip = WrongPass;
                    keyPadAu.Play();
                }
            }
        }
        
        if(correct == true)
        {
            playerCode = "correct";
        }
    }

    public void keyPassword()
    { 
        playerCode += gameObject.name;
        digitCount++;
        keyPadAu.clip = ButtonPress;
        keyPadAu.Play();

    }
}
