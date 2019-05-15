using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public GameObject LoadingScene;

    public void SwitchScene(string scene)
    {
        LoadingScene.SetActive(true);
        Scene current = SceneManager.GetActiveScene();
        string sceneName = current.name;
        StartCoroutine(LoadAsync(scene));
    }

    IEnumerator LoadAsync (string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }
    }
}
