using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool select = false;
    public string Function;
    public string ItemToUse;
    public GameObject ObjAppear;
    public AudioSource InteractingSound;
    public bool destroy;
    public int DialogueTag;
    public int ExploTag;


    //destroy

    private void OnMouseDown()
    {
        select = true;
    }

}
