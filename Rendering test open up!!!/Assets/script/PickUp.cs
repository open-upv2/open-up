using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class PickUp : MonoBehaviour
{
    public bool walk = false;
    public GameObject player;
    public Inventory inventory;
    public GameObject ObjectPick;
    public GameObject ObjectUse;
    public GameObject ObjectChange;
    public GameObject InvenObject;
    public GameObject need;
    public GameObject need2;
    public GameObject need3;
    public string scene;
    int over;

    void OnMouseDown()
    {
            if (player.transform.position.x < ObjectPick.transform.position.x && player != null)
            {
                player.transform.position = new Vector3(ObjectPick.transform.position.x, player.transform.position.y, 0.0f)/*ObjectPick.transform.position*/;
            }
            else if (player.transform.position.x > ObjectPick.transform.position.x && player != null)
            {
                player.transform.position = new Vector3(ObjectPick.transform.position.x, player.transform.position.y, 0.0f)/*ObjectPick.transform.position*/;
        }

        if(need.activeSelf == true && need2.activeSelf == true)
        {
            if(ObjectPick != null)
            {
                ObjectPick.SetActive(false);
            }
            if (InvenObject != null)
            {
                InvenObject.SetActive(true);
            }
            if (ObjectUse != null)
            {
                ObjectUse.SetActive(false);
            }
            if(ObjectChange != null)
            {
                ObjectChange.SetActive(true);
            }
        }
        else if (need3 != null && need2.activeSelf == true && need3.activeSelf == true)
        {
            if (ObjectPick != null)
            {
                ObjectPick.SetActive(false);
            }
            if (InvenObject != null)
            {
                InvenObject.SetActive(true);
            }
            if (ObjectUse != null)
            {
                ObjectUse.SetActive(false);
            }
            if (ObjectChange != null)
            {
                ObjectChange.SetActive(true);
            }
        }

    }

}