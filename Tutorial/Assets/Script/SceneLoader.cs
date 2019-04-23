using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void SwitchScene(string scene)
    {
        Scene current = SceneManager.GetActiveScene();
        string sceneName = current.name;

        SceneManager.LoadScene(scene);
    }
}
