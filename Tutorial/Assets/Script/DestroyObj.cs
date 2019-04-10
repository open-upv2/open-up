using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public GameObject NextObj;
    private void OnMouseDown()
    {
        NextObj.SetActive(true);
        Destroy(gameObject);
    }
}
