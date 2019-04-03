using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObj : MonoBehaviour
{
    public bool select = false;
    public string Say = "Helmet";

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        select = (!select);
    }
}
