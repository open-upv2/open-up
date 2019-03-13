using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharlisText : MonoBehaviour
{
    [SerializeField]
    private Text Charlis = null;

    public bool countText = false;
    string charlis1 = "Let's go fight baddies!";
    string charlis2 = "Hmmm... What a creepy house.";

    // Start is called before the first frame update
    void Start()
    {
        Charlis.text = charlis1;

    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !countText)
        {
            Charlis.text = charlis1;
            countText = true;
        }
        else if(Input.GetMouseButton(0) && countText)
        {
            Charlis.text = charlis2;
        }
    }

}
