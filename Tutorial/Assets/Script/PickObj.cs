using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObj : MonoBehaviour
{
    public bool select = false;
    public int numberTag;
    public string ObjectPicked;
    public string need1;
    public string need2;
    public GameObject InvenItem;
    public GameObject UseItem;
    public GameObject UseItem2;
    public bool destroy;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        select = true;
    }
}
