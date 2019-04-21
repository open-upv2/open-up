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
    public AudioSource PickingSound;
    public AudioSource UsingSound;
    GameObject[] Collectable;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject item in Collectable)
        {
            item.GetComponent<PickObj>().select = false;
        }
        select = true;
    }
}
