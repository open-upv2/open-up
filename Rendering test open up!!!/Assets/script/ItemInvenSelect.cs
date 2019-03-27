using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInvenSelect : MonoBehaviour
{
    public GameObject select;
    public GameObject[] SelectTag;
    public GameObject Select1;
    public GameObject Item1;
    public GameObject Select2;
    public GameObject Result;
    public GameObject Item2;
    public string CombineSC;

    [SerializeField]
    private Text CharlisText = null;

    public void ItemCombine()
    {
        if(Select1 != null)
        {
            if (Select1.activeSelf == true && Item1.activeSelf == true && Select2.activeSelf == true)
            {
                Select2.SetActive(false);
                Result.SetActive(true);
                if (Item2 != null)
                {
                    Item2.SetActive(false);
                }
                if(CombineSC != null)
                {
                    CharlisText.text = CombineSC;
                }
            }
        }
    }

    public void ItemSelect()
    {
        SelectTag = GameObject.FindGameObjectsWithTag("InvenSelect");
        foreach (GameObject selected in SelectTag)
        {
            selected.SetActive(false);
        }
        select.SetActive(true);
    }
}
