using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float speed = 4.0f;
    Vector3 target;

    private List<string> Inventory = new List<string>();
    int InvenSize = 0;

    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;
    public GameObject playerText;
    public Animator PlayerAnimator;
    public Animation Interacting;
    int a = 0;
    bool faceLeft = true;

    enum ObjectPick
    {
        Helmet = 0
    }

    string[] ObjectNamePick = new string[]
    {
        "Helmet",
        "Apple"
    };

    string[] DialoguePick = new string[]
    {
        "",
        "Is it that guy's...?",
        "Yummy!"
    };

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
        playerText.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            PlayerAnimator.SetBool("CollectItem", false);
            PlayerAnimator.SetBool("Walk", true);
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = gameObject.transform.position.y;
            target.z = gameObject.transform.position.z;
        }
        //turn left-right
        if(target.x < gameObject.transform.position.x && faceLeft == false)
        {
            faceLeft = true;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if(target.x > gameObject.transform.position.x && faceLeft == true)
        {
            faceLeft = false;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(gameObject.transform.position == target)
        {
            PlayerAnimator.SetBool("Walk", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickObj>() != null && collision.gameObject.GetComponent<PickObj>().select)
        {
            if(collision.gameObject.GetComponent<PickObj>().need1 == "")
            {
                PlayerAnimator.SetBool("CollectItem", true);
                Inventory.Add(ObjectNamePick[collision.gameObject.GetComponent<PickObj>().nameTag]);
                InvenSize++;
                Debug.Log(ObjectNamePick[collision.gameObject.GetComponent<PickObj>().nameTag]);
                a = collision.gameObject.GetComponent<PickObj>().numberTag;
                StartCoroutine(ShowText());
                Debug.Log("Destroy");
                Destroy(collision.gameObject);
                StopCoroutine(ShowText());
                Debug.Log(Inventory[0]);
            }
            else
            {
                for (int i = 0; i < InvenSize; i++)
                {
                    if (collision.gameObject.GetComponent<PickObj>().need1 == Inventory[i])
                    {
                        PlayerAnimator.SetBool("CollectItem", true);
                        Inventory.Add(ObjectNamePick[collision.gameObject.GetComponent<PickObj>().nameTag]);
                        Debug.Log(ObjectNamePick[collision.gameObject.GetComponent<PickObj>().nameTag]);
                        a = collision.gameObject.GetComponent<PickObj>().numberTag;
                        StartCoroutine(ShowText());
                        Debug.Log("Destroy");
                        Destroy(collision.gameObject);
                        StopCoroutine(ShowText());
                        break;
                    }
                }
            }
        }
        else if (collision.gameObject.tag == "Arrow")
        {
            Debug.Log("Change Scene");
            ChangeScene(collision.gameObject.GetComponent<Arrow>().NextScene, collision.gameObject.GetComponent<Arrow>().CharacterPos);
        }

    }

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public string ClarisText;
    public string previous = "";

    public IEnumerator ShowText()
    {
        ClarisText = DialoguePick[a];
        for (int i = 0; i <= ClarisText.Length; i++)
        {
            currentText = ClarisText.Substring(0, i);
            playerText.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void ChangeScene(int Scene, string CPos)
    {
        switch (Scene)
        {
            case 1:
                Debug.Log("Go to front");
                break;
            case 2:
                Debug.Log("Go to right");
                break;
            case 3:
                Debug.Log("Go to left");
                break;
            default:
                Debug.Log("Go to back");
                break;
        }
        Debug.Log(CPos);
    }

}
