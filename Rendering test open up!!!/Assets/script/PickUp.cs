using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    public GameObject ObjectPick;
    public GameObject InvenObject;
    public GameObject need;
    public string scene;
    int over;

    static int InvenCount = 0;

    void OnMouseDown()
    {
        //if (require == "")
        //{
        if(/*need != null && */need.activeSelf == true)
        {
            ObjectPick.SetActive(false);
            InvenObject.SetActive(true);
            InvenCount++;
            if (InvenCount >= 1)
            {
                InvenObject.transform.Translate((InvenCount - 1) * 1, 0, 0);
            }
            Debug.Log(InvenCount);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

}