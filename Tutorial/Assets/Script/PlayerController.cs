using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float speed = 4.0f;
    public Vector3 target;

    private List<string> Inventory = new List<string>();
    int InvenSize = 0;
    

    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;
    public GameObject playerText;
    public Animator PlayerAnimator;
    public AudioSource ThemeSong;
    public Animation Interacting;
    public GameObject[] AllScene;
    int a = 0;
    bool faceLeft = true;
    bool walk = true;
    bool interact = false;

    string[] DialoguePick = new string[]
    {
        "",
        "Well, this is an alien sense of decorating alright...",//pick battery from flashlight
        "Well even if they aren't aliens I'll be sure to call them out for their trashing habits.", //pick battery on ground
        "I don't think you throw the thing you clean with out when you clean up.", //Pick vacum
        "Huh, it's still working fine... Wonder why they threw it out?" //Pick termite
    };

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
        playerText.GetComponent<Text>().text = "";
        ThemeSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && walk == true && interact == false)
        {
            walk = false;
            playerText.GetComponent<Text>().text = "";
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
            playerText.transform.Rotate(new Vector3(0, 180, 0));
        }
        else if(target.x > gameObject.transform.position.x && faceLeft == true)
        {
            faceLeft = false;
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
            playerText.transform.Rotate(new Vector3(0, 180, 0));
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(gameObject.transform.position == target)
        {
            PlayerAnimator.SetBool("Walk", false);
            walk = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickObj>() != null && collision.gameObject.GetComponent<PickObj>().select)
        {
            PickObj ObjPick = collision.gameObject.GetComponent<PickObj>();
            if (ObjPick.need1 == "")
            {
                target = gameObject.transform.position;
                PlayerAnimator.SetBool("CollectItem", true);
                if (ObjPick.ObjectPicked != "")
                {
                    Inventory.Add(ObjPick.ObjectPicked);
                    InvenSize++;
                    Debug.Log("Add");
                    Debug.Log(ObjPick.ObjectPicked);
                    if (ObjPick.InvenItem != null)
                        ObjPick.InvenItem.SetActive(true);
                }

                a = ObjPick.numberTag;
                StartCoroutine(ShowText());
                ObjPick.select = false;
                if (ObjPick.destroy == true)
                {
                    Destroy(collision.gameObject);
                }
                StopCoroutine(ShowText());
            }
            else
            {
                for (int i = 0; i < InvenSize; i++)
                {
                    if (ObjPick.need1 == Inventory[i])
                    {
                        if(ObjPick.need2 != "")
                        {
                            for (int j = 0; j < InvenSize; j++)
                            {
                                if (ObjPick.need2 == Inventory[j])
                                {
                                    target = gameObject.transform.position;
                                    PlayerAnimator.SetBool("CollectItem", true);
                                    Inventory.Add(ObjPick.ObjectPicked);
                                    InvenSize++;
                                    Debug.Log("Add");
                                    Debug.Log(ObjPick.ObjectPicked);
                                    a = ObjPick.numberTag;
                                    if (ObjPick.InvenItem != null)
                                        ObjPick.InvenItem.SetActive(true);
                                    if (ObjPick.UseItem != null)
                                    {
                                        Destroy(ObjPick.UseItem);
                                    }
                                    if (ObjPick.UseItem2 != null)
                                    {
                                        Destroy(ObjPick.UseItem2);
                                    }
                                    StartCoroutine(ShowText());
                                    if (ObjPick.destroy == true)
                                    {
                                        Destroy(collision.gameObject);
                                    }
                                    StopCoroutine(ShowText());
                                    break;
                                }

                            }

                        }
                        else
                        {
                            target = gameObject.transform.position;
                            PlayerAnimator.SetBool("CollectItem", true);
                            Inventory.Add(ObjPick.ObjectPicked);
                            InvenSize++;
                            Debug.Log("Add");
                            Debug.Log(ObjPick.ObjectPicked);
                            a = ObjPick.numberTag;
                            if (ObjPick.InvenItem != null)
                                ObjPick.InvenItem.SetActive(true);
                            if (ObjPick.UseItem != null)
                            {
                                Destroy(ObjPick.UseItem);
                            }
                            if (ObjPick.UseItem2 != null)
                            {
                                Destroy(ObjPick.UseItem2);
                            }
                            StartCoroutine(ShowText());
                            if (ObjPick.destroy == true)
                            {
                                Destroy(collision.gameObject);
                            }
                            StopCoroutine(ShowText());
                            break;
                        }
                        
                    }
                }
            }
        }
        else if (collision.gameObject.tag == "Arrow" && collision.gameObject.GetComponent<Arrow>().select)
        {
            PlayerAnimator.SetBool("Turn", true);
            ChangeScene(collision.gameObject.GetComponent<Arrow>().NextScene, collision.gameObject.GetComponent<Arrow>().CharacterPos);
            collision.gameObject.GetComponent<Arrow>().select = false;
            collision.gameObject.GetComponent<Arrow>().ArrowImage.SetActive(false);
        }
        else if (collision.gameObject.tag == "Interact" && collision.gameObject.GetComponent<Interact>().select)
        {
            target = gameObject.transform.position;
            Interact ObjFunction = collision.gameObject.GetComponent<Interact>();
            if (ObjFunction.Function == "ClickToDestroy")
            {
                if (ObjFunction.ObjAppear != null)
                {
                    ObjFunction.ObjAppear.SetActive(true);
                }
                Destroy(collision.gameObject);
            }

        }
    }

    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public string ClarisText;
    public string previous = "";

    public IEnumerator ShowText()
    {
        interact = true;
        ClarisText = DialoguePick[a];
        for (int i = 0; i <= ClarisText.Length; i++)
        {
            currentText = ClarisText.Substring(0, i);
            playerText.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
        PlayerAnimator.SetBool("CollectItem", false);
        interact = false;
    }

    void ChangeScene(GameObject Scene, string CPos)
    {
        AllScene = GameObject.FindGameObjectsWithTag("Scene");
        foreach (GameObject scene in AllScene)
        {
            scene.SetActive(false);
        }
        Scene.SetActive(true);
        if(CPos == "right")
        {
            gameObject.transform.position = new Vector3(6.0f, gameObject.transform.position.y, 0.0f);
        }
        else if(CPos == "left")
        {
            gameObject.transform.position = new Vector3(-6.0f, gameObject.transform.position.y, 0.0f);
        }
        else if(CPos == "middle")
        {
            gameObject.transform.position = new Vector3(0.0f, gameObject.transform.position.y, 0.0f);
        }
        PlayerAnimator.SetBool("Turn", false);
        target = transform.position;
    }

}
