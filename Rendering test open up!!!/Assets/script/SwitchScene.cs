using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class SwitchScene : MonoBehaviour
{
    public void sceneSwitch(int arrow)
    {
        if (Camera.main.gameObject.transform.position.x <= 1)
        { //front
            if (arrow == 1)
            {
                //R
                Camera.main.transform.Translate(45.17f, 0, 0);
            }
            else if (arrow == 2)
            {
                //L
                Camera.main.transform.Translate(21.58f, 0, 0);
            }
        }
        else if (Camera.main.gameObject.transform.position.x >= 40.0f)
        {
            //f
            if (arrow == 2)
            {
                Camera.main.transform.Translate(-45.17f, 0, 0);
            }
        }
        else
        {
            //f
            if (arrow == 1)
            {
                Camera.main.transform.Translate(-21.58f, 0, 0);
            }

        }
    }
    public void SceneLoader(string scene)
    {
        Scene current = SceneManager.GetActiveScene();
        string sceneName = current.name;

        SceneManager.LoadScene(scene);
    }
}