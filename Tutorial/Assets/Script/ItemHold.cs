using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHold : MonoBehaviour
{

    public PlayerController PlayerControl;

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        transform.Translate(25, -25, 0);
    }
}
