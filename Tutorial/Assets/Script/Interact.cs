using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public bool select = false;
    public string Function;
    public GameObject ObjAppear;
    public AudioSource InteractingSound;

    private void OnMouseDown()
    {
        select = (!select);
    }

}
