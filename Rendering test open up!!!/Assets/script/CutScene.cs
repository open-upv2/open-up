using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public GameObject CurScene;
    public GameObject NextScene;

    // Start is called before the first frame update
    public void SwitchCutScene()
    {
        CurScene.SetActive(false);
        if(NextScene!= null)
        NextScene.SetActive(true);
    }

}
