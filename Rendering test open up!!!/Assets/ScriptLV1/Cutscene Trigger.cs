using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject Cutscene;
    public GameObject Interface;

    public void CStrigger()
    {
        Cutscene.SetActive(true);
        Cutscene.SetActive(false);
    }
}
