using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public GameObject CurScene;
    public GameObject NextScene;
    public GameObject CutSceneText;
    public GameObject End;
    public GameObject Start;
    public string Dialogue;

    // Start is called before the first frame update
    public void Awake()
    {
        StartCoroutine(ShowText());
        StopCoroutine(ShowText());
    }

    public void ToNextScene()
    {
        CurScene.SetActive(false);
        if (NextScene != null)
            NextScene.SetActive(true);
        if(End != null)
        {
            End.SetActive(false);
        }
        if(Start != null)
        {
            Start.SetActive(true);
        }

    }

    string currentText = "";
    string ClarisText;

    public IEnumerator ShowText()
    {
        ClarisText = Dialogue;
        for (int i = 0; i <= ClarisText.Length; i++)
        {
            currentText = ClarisText.Substring(0, i);
            CutSceneText.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
    }
}