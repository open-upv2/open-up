using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


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
    public GameObject PlayerText;
    public string CanPick;
    public string CanNot;
    public string scene;
    int over;

    [SerializeField]
    private Text CharlisText = null;

    void OnMouseDown()
    {
            if (player.transform.position.x < ObjectPick.transform.position.x && player != null)
            {
                player.transform.position = new Vector3(ObjectPick.transform.position.x, player.transform.position.y, 0.0f);
            }
            else if (player.transform.position.x > ObjectPick.transform.position.x && player != null)
            {
                player.transform.position = new Vector3(ObjectPick.transform.position.x, player.transform.position.y, 0.0f);
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
            if(CanPick != null)
            {
                PlayerText.SetActive(true);
                CharlisText.text = CanPick;
            }
            else
            {
                PlayerText.SetActive(false);

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
            if (CanPick != null)
            {
                PlayerText.SetActive(true);
                CharlisText.text = CanPick;
            }
            else
            {
                PlayerText.SetActive(false);
            }

        }
        else
        {
            if (CanNot != null)
            {
                PlayerText.SetActive(true);
                CharlisText.text = CanNot;
            }
            else
            {
                PlayerText.SetActive(false);

            }

        }

    }

}