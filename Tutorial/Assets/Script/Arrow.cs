using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject ArrowImage;
    public GameObject NextScene;
    public string CharacterPos;
    public bool select = false;

    private void OnMouseOver()
    {
        ArrowImage.SetActive(true);
    }

    private void OnMouseExit()
    {
        ArrowImage.SetActive(false);
    }

    private void OnMouseDown()
    {
        select = true;
    }

}
