using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject ArrowImage;
    public int NextScene;
    public string CharacterPos;

    private void OnMouseOver()
    {
        ArrowImage.SetActive(true);
    }

    private void OnMouseExit()
    {
        ArrowImage.SetActive(false);
    }

}
