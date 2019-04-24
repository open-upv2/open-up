using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    float speed = 4.0f;
    public Vector3 target;
    public Cursor cursor;

    //Use In Inventory
    //public List<string> Inventory = new List<string>();
    public List<Item> Innventory = new List<Item>();
    public int InvenSize = 0;
    public bool interact = false;
    public int SelectItem;
    public bool Hold;
    public Sprite Blank;

    public GameObject playerText;
    Text PlayerDialogue;
    public Animator PlayerAnimator;
    public AudioSource ThemeSong;
    public Animation Interacting;
    public GameObject[] AllScene;
    GameObject[] Collectable;
    int a = 0;
    bool faceLeft = true;
    bool walk = true;
    public float moveSpeed;
    public bool stayStill = false;

    string[] DialoguePick = new string[]
    {
        "",
        "Well, this is an alien sense of decorating alright...",//1 pick battery from flashlight
        "I know they say don't throw these in the bin but...", //2 pick battery on ground
        "Ironic..", //3 Pick vacum
        "Huh, it's still working fine... Wonder why they threw it out?", //4 Pick termite
        "Need another one...", //5 Put in 1 battery
        "Should be up and running..." //6 Put in 2 Battery
        
    };

    string[] DialogueExplore = new string[]
    {
        "",
        "Lock",
        "What a huge anthill!",
        "No batteries",
        "Need another one...", //5 Put in 1 battery
    };

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
        PlayerDialogue = playerText.GetComponent<Text>();
        PlayerDialogue.text = "";
        ThemeSong.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (stayStill == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                walk = false;
                PlayerDialogue.text = "";
                PlayerAnimator.SetBool("CollectItem", false);
                PlayerAnimator.SetBool("Walk", true);
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.y = gameObject.transform.position.y;
                target.z = gameObject.transform.position.z;
            }
            //turn left-right
            if (target.x < gameObject.transform.position.x && faceLeft == false)
            {
                faceLeft = true;
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                playerText.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (target.x > gameObject.transform.position.x && faceLeft == true)
            {
                faceLeft = false;
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                playerText.transform.Rotate(new Vector3(0, 180, 0));
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (gameObject.transform.position == target)
            {
                PlayerAnimator.SetBool("Walk", false);
                walk = true;
            }
        }
            

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickObj>() != null && collision.gameObject.GetComponent<PickObj>().select)
        {
            PickObj ObjPick = collision.gameObject.GetComponent<PickObj>();
            AudioSource PlayerAudio = gameObject.GetComponent<AudioSource>();
            PlayerAudio.clip = ObjPick.PickingSound;
            if (ObjPick.ItemToUse == "") //No item needed
            {
                stayStill = true; //cannot walk
                target = gameObject.transform.position; //stay in that place
                PlayerAnimator.SetBool("CollectItem", true); // play animation
                Item tmp = new Item();
                tmp.ItemImage = ObjPick.ItemImage;
                tmp.ItemName = ObjPick.ItemName;
                if(ObjPick.pick == true)
                {
                    Innventory.Add(tmp); // add item to inventory
                    InvenSize++;
                }
                if (ObjPick.PickingSound != null) // Play audio
                {
                    PlayerAudio.Play();
                    Debug.Log("Sound");
                }

                a = ObjPick.DialogueTag; //update player text
                StartCoroutine(ShowText());
                Destroy(collision.gameObject);
                StopCoroutine(ShowText());
            }
            else
            {
                if(Hold == true && ObjPick.ItemToUse == Innventory[SelectItem].ItemName)
                {
                    stayStill = true;
                    target = gameObject.transform.position;
                    PlayerAnimator.SetBool("CollectItem", true);
                    Item tmp = new Item();
                    tmp.ItemImage = ObjPick.ItemImage;
                    tmp.ItemName = ObjPick.ItemName;
                    if (ObjPick.pick == true)
                    {
                        Innventory.Add(tmp); // add item to inventory
                        InvenSize++;
                    }
                    if (ObjPick.PickingSound != null)
                    {
                        PlayerAudio.Play();
                    }
                    a = ObjPick.DialogueTag;
                    StartCoroutine(ShowText());
                    if (ObjPick.destroy == true)
                    {
                        Destroy(collision.gameObject);
                    }
                    StopCoroutine(ShowText());
                    Innventory.Remove(Innventory[SelectItem]);
                    InvenSize--;
                    Hold = false;
                    cursor.GetComponent<Image>().sprite = Blank;
                }
                else
                {
                    stayStill = true;
                    target = gameObject.transform.position;
                    a = ObjPick.ExploDiaTag;
                    StartCoroutine(ShowTextExplo());
                    ObjPick.select = false;
                }
            }
        }
        else if (collision.gameObject.tag == "Arrow" && collision.gameObject.GetComponent<Arrow>().select)
        {
            Arrow SelectedArrow;
            SelectedArrow = collision.gameObject.GetComponent<Arrow>();
            PlayerAnimator.SetBool("Turn", true);
            ChangeScene(SelectedArrow.NextScene, SelectedArrow.CharacterPos);
            SelectedArrow.select = false;
            SelectedArrow.ArrowImage.SetActive(false);
        }
        else if (collision.gameObject.tag == "Interact" && collision.gameObject.GetComponent<Interact>().select)
        {
            target = gameObject.transform.position;
            Interact ObjFunction = collision.gameObject.GetComponent<Interact>();
            if (ObjFunction.Function == "ClickToDestroy")
            {
                if(ObjFunction.ItemToUse == "")
                {
                    PlayerAnimator.SetBool("CollectItem", true); // play animation
                    if (ObjFunction.InteractingSound != null)
                    {
                        ObjFunction.InteractingSound.Play();
                    }
                    if (ObjFunction.ObjAppear != null)
                    {
                        ObjFunction.ObjAppear.SetActive(true);
                    }
                    a = ObjFunction.DialogueTag;
                    StartCoroutine(ShowText());
                    StopCoroutine(ShowText());
                    Destroy(collision.gameObject);
                }
                else
                {
                    if (Hold == true && ObjFunction.ItemToUse == Innventory[SelectItem].ItemName)
                    {
                        PlayerAnimator.SetBool("CollectItem", true); // play animation
                        stayStill = true;
                        target = gameObject.transform.position;
                        PlayerAnimator.SetBool("CollectItem", true);
                        a = ObjFunction.DialogueTag;
                        StartCoroutine(ShowText());
                        StopCoroutine(ShowText());
                        Innventory.Remove(Innventory[SelectItem]);
                        InvenSize--;
                        Hold = false;
                        cursor.GetComponent<Image>().sprite = Blank;
                        if (ObjFunction.InteractingSound != null)
                        {
                            ObjFunction.InteractingSound.Play();
                        }
                        if (ObjFunction.ObjAppear != null)
                        {
                            ObjFunction.ObjAppear.SetActive(true);
                        }
                        if (ObjFunction.destroy == true)
                        {
                            Destroy(collision.gameObject);
                        }
                        else
                        {
                            ObjFunction.select = false;
                        }

                    }
                    else
                    {
                        stayStill = true;
                        target = gameObject.transform.position;
                        a = ObjFunction.ExploTag;
                        StartCoroutine(ShowTextExplo());
                        //StopCoroutine(ShowTextExplo());
                        ObjFunction.select = false;
                    }
                }

            }
            else if(ObjFunction.Function == "dropObject")
            {
                PlayerAnimator.SetBool("CollectItem", true); // play animation
                if (ObjFunction.InteractingSound != null)
                {
                    ObjFunction.InteractingSound.Play();
                }
                if (ObjFunction.ObjAppear != null)
                {
                    ObjFunction.ObjAppear.SetActive(true);
                }
                //while (ObjFunction.ObjAppear.transform.position.y > -3.0f)
                //{
                //    ObjFunction.ObjAppear.transform.Translate(0.0f, ObjFunction.ObjAppear.transform.position.y + 0.4f, 0.0f);/*position = Vector3.MoveTowards(transform.position, FallingPos, speed * Time.deltaTime);*/
                //}
                a = ObjFunction.DialogueTag;
                StartCoroutine(ShowText());
                StopCoroutine(ShowText());
                if (ObjFunction.destroy == true)
                {
                    Destroy(collision.gameObject);
                }
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
            PlayerDialogue.text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
        PlayerAnimator.SetBool("CollectItem", false);
        stayStill = false;
    }

    public IEnumerator ShowTextExplo()
    {
        interact = true;
        ClarisText = DialogueExplore[a];
        for (int i = 0; i <= ClarisText.Length; i++)
        {
            currentText = ClarisText.Substring(0, i);
            PlayerDialogue.text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
        PlayerAnimator.SetBool("CollectItem", false);
        stayStill = false;
    }

    void ChangeScene(GameObject Scene, string CPos)
    {
        AllScene = GameObject.FindGameObjectsWithTag("Scene");
        foreach (GameObject scene in AllScene)
        {
            scene.SetActive(false);
        }
        Scene.SetActive(true);
        if (CPos == "right")
        {
            gameObject.transform.position = new Vector3(6.0f, gameObject.transform.position.y, 0.0f);
        }
        else if (CPos == "left")
        {
            gameObject.transform.position = new Vector3(-6.0f, gameObject.transform.position.y, 0.0f);
        }
        else if (CPos == "middle")
        {
            gameObject.transform.position = new Vector3(0.0f, gameObject.transform.position.y, 0.0f);
        }
        PlayerAnimator.SetBool("Turn", false);
        target = transform.position;
    }



}
