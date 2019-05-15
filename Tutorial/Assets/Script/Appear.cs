using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject appearObject;
    public GameObject destroyObject;
    public bool destroy;

    private void OnDestroy()
    {
        appearObject.SetActive(true);
        if(destroy == true)
        {
            Destroy(destroyObject);
        }
    }


}
