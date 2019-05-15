using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //cache
    private SoundManager1 soundManager;

    //Cursor
    public Texture2D cursorDefault;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    float speed = 4.0f;
    public Vector3 target;
    public ItemHold cursor;

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
    public AudioSource SFX;
    public AudioSource ThemeSong;
    public Animation Interacting;
    public GameObject[] AllScene;
    GameObject[] Collectable;
    int a = 0;
    bool faceLeft = true;
    bool walk = true;
    public float moveSpeed;
    public bool stayStill = false;

    public AudioClip Walking;
    

    string[] DialoguePick = new string[]
    {
        "",

        //Phase 1
        "What an alien sense of decoration...", //falshlight 1 -
        "Maybe I can save electricity costs like this too...", //flashlight battery 2 -
        /****/"I don't think the bird wants this baby...", //pick battery from bird nest 3 -
        "Huff...huff... huh, what's down there?", //trash pile 4 -
        "I'm so sorry!", //bird nest 5 -
        "Surprisingly easy to breach for aliens...", //wire fence L 6 -
        "Surprisingly easy to breach for aliens...", //wire fence R 7 -
        "Who knows what they're cooking...", //Gas tank 8 - 
        "These guys seem a bit... strange?", //Termite 9 - 

        //Phase2
        "That's not the open button... uh oh.", //metal red button 10 - 
        "I'm a wizard! Oh I wish...", //Broom 11 - 
        "It's breaking... just one more time...", //UFO first 12 -
        "There we- ew, what's that?", //UFO second 13 -
        "I'm doing cleaning for them. Ugh.", //Leaves Pile 14 - 
        "The front door doesn't have a keyhole... hmm...", //key 15 - 
        "Let's see... oh boy.", //Locker 16 - 
        "Empty, but feels like not for much longer.", //flask 17 -
        "Best be careful...", //green goo 18 -
        "Am I a mad scientist...?", //broken termite 19 - 
        "They seem to like it in here.", //neotermite 20 - 
        "I'm feeling... different.", //fallen flashlight 21 - 
        "I'm having a bad case of deja vu...", //Gas at termite 22 - 
        "This place isn't made of wood for sure.", //shoot gas tank 23 -



    };

    string[] DialogueExplore = new string[]
    {
        "",
        //Phase 1
        "Looks like the birds aren't here...", //bird nest 1 -
        "I wish I had this much to hoard.", //Trash bin 2 -
        "If only I had my gear with me right now...", //wire fence 3 -
        "Termites! Freaky little guys.", //termite 4 - 
        "Cheapstake aliens... relatable.", //Wooden door 5 -

        //phase 2
        "And I wasted my explosive! Grahh!", //Metal Door 6 -
        "Something's behind there...", //Broken termite 7 -
        "Doesn't look like household things will damage it.",//UFO 8 -
        "Not touching that with my bare hands...", //Leaves pile 9 -
        "Locked. Called a Locker for a reason.", //Locker 10 -
        "I feel like living today, thanks.", //green goo 11 -
        "Looks like they want to eat my hand off.", //neo termite 12 -

        //phase 3
        "...Why not just have no door?", //alien wall 13 -
        "Not much use as is.", //fallen flashlight 14 -
        "No termites left.", //neo termite after 15 -

        "I don't think that will work...", //16 -


    };

    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
        PlayerDialogue = playerText.GetComponent<Text>();
        PlayerDialogue.text = "";
        ThemeSong.Play();

        //caching
        soundManager = SoundManager1.instacne;
        if(soundManager == null)
        {
            Debug.LogError("No sound manager found");
        }
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
                SFX.clip = Walking;
                SFX.Play();
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(target.y > 2.0f)
                {
                    target = transform.position;
                }
                else
                {
                    target.y = gameObject.transform.position.y;
                    target.z = gameObject.transform.position.z;
                }

            }
            //turn left-right
            if (target.x > gameObject.transform.position.x && faceLeft == false && walk == false)
            {
                faceLeft = true;
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                playerText.transform.Rotate(new Vector3(0, 180, 0));
            }
            else if (target.x < gameObject.transform.position.x && faceLeft == true && walk == false)
            {
                faceLeft = false;
                gameObject.transform.Rotate(new Vector3(0, 180, 0));
                playerText.transform.Rotate(new Vector3(0, 180, 0));
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


            if (gameObject.transform.position == target)
            {
                PlayerAnimator.SetBool("Walk", false);
                SFX.Stop();
                walk = true;
            }
        }
        else
        {
            target = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Stop");
        PlayerAnimator.SetBool("Walk", false);
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
                PlayerAnimator.SetBool(ObjPick.AniName, true); // play animation
                Item tmp = new Item();
                tmp.ItemImage = ObjPick.ItemImage;
                tmp.ItemName = ObjPick.ItemName;
                if(ObjPick.pick == true)
                {
                    Innventory.Add(tmp); // add item to inventory
                    InvenSize++;
                }
                soundManager.PlaySound(ObjPick.soundName);


                a = ObjPick.DialogueTag; //update player text
                StartCoroutine(ShowText());
                Destroy(collision.gameObject);
                Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
                StopCoroutine(ShowText());
            }
            else
            {
                if(Hold == true && ObjPick.ItemToUse == Innventory[SelectItem].ItemName)
                {
                    stayStill = true;
                    target = gameObject.transform.position;
                    PlayerAnimator.SetBool(ObjPick.AniName, true); // play animation
                    Item tmp = new Item();
                    tmp.ItemImage = ObjPick.ItemImage;
                    tmp.ItemName = ObjPick.ItemName;
                    if (ObjPick.pick == true)
                    {
                        Innventory.Add(tmp); // add item to inventory
                        InvenSize++;
                    }
                    soundManager.PlaySound(ObjPick.soundName);

                    a = ObjPick.DialogueTag;
                    StartCoroutine(ShowText());
                    if (ObjPick.destroy == true)
                    {
                        Destroy(collision.gameObject);
                        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
                    }
                    StopCoroutine(ShowText());
                    if(ObjPick.removeInven == true)
                    {
                        Innventory.Remove(Innventory[SelectItem]);
                        InvenSize--;
                    }
                    Hold = false;
                    cursor.GetComponent<Image>().sprite = Blank;
                }
                else if(Hold == true)
                {
                    stayStill = true;
                    target = gameObject.transform.position;
                    a = 16;
                    StartCoroutine(ShowTextExplo());
                    ObjPick.select = false;
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
            Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
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
                    PlayerAnimator.SetBool(ObjFunction.AniName, true); // play animation
                    if (ObjFunction.ObjAppear != null)
                    {
                        ObjFunction.ObjAppear.SetActive(true);
                    }
                    a = ObjFunction.DialogueTag;
                    soundManager.PlaySound(ObjFunction.soundName);

                    StartCoroutine(ShowText());
                    StopCoroutine(ShowText());
                    Destroy(collision.gameObject);
                    Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
                }
                else
                {
                    if (Hold == true && ObjFunction.ItemToUse == Innventory[SelectItem].ItemName)
                    {
                        PlayerAnimator.SetBool(ObjFunction.AniName, true); // play animation
                        stayStill = true;
                        target = gameObject.transform.position;
                        a = ObjFunction.DialogueTag;
                        StartCoroutine(ShowText());
                        StopCoroutine(ShowText());
                        if(ObjFunction.removeInven == true)
                        {
                            Innventory.Remove(Innventory[SelectItem]);
                            InvenSize--;
                        }
                        Hold = false;
                        soundManager.PlaySound(ObjFunction.soundName);

                        cursor.GetComponent<Image>().sprite = Blank;
                        if (ObjFunction.ObjAppear != null)
                        {
                            ObjFunction.ObjAppear.SetActive(true);
                        }
                        if (ObjFunction.destroy == true)
                        {
                            Destroy(collision.gameObject);
                            Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
                        }
                        else
                        {
                            ObjFunction.select = false;
                        }


                    }
                    else if (Hold == true)
                    {
                        stayStill = true;
                        target = gameObject.transform.position;
                        a = 16;
                        StartCoroutine(ShowTextExplo());
                        ObjFunction.select = false;
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
                if (ObjFunction.ItemToUse == "")
                {
                    PlayerAnimator.SetBool(ObjFunction.AniName, true); // play animation
                    soundManager.PlaySound(ObjFunction.soundName);
                    if (ObjFunction.InteractingSound != null)
                    {
                        ObjFunction.InteractingSound.Play();
                    }
                    if (ObjFunction.ObjAppear != null)
                    {
                        ObjFunction.ObjAppear.SetActive(true);
                    }
                    if(ObjFunction.destroy == true)
                    {
                        Destroy(collision.gameObject);
                    }
                    a = ObjFunction.DialogueTag;
                    StartCoroutine(ShowText());
                    StopCoroutine(ShowText());
                    Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
                }
                else
                {
                    //soundManager.PlaySound()

                    if (Hold == true && ObjFunction.ItemToUse == Innventory[SelectItem].ItemName)
                    {
                        PlayerAnimator.SetBool(ObjFunction.AniName, true); // play animation
                        soundManager.PlaySound(ObjFunction.soundName);
                        stayStill = true;
                        target = gameObject.transform.position;
                        a = ObjFunction.DialogueTag;
                        StartCoroutine(ShowText());
                        StopCoroutine(ShowText());
                        if (ObjFunction.removeInven == true)
                        {
                            Innventory.Remove(Innventory[SelectItem]);
                            InvenSize--;
                        }
                        Hold = false;
                        cursor.GetComponent<Image>().sprite = Blank;
                        soundManager.PlaySound(ObjFunction.soundName);

                        if (ObjFunction.ObjAppear != null)
                        {
                            ObjFunction.ObjAppear.SetActive(true);
                        }
                        if (ObjFunction.destroy == true)
                        {
                            Destroy(collision.gameObject);
                            Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
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
            else if (ObjFunction.Function == "ZoomIn")
            {
                PlayerAnimator.SetBool("Walk", false);
                SFX.Stop();
                target = transform.position;
                if (ObjFunction.ObjAppear != null)
                {
                    ObjFunction.ObjAppear.SetActive(true);
                    stayStill = true;
                }
                //        //soundManager.PlaySound()
                //        soundManager.PlaySound(ObjFunction.soundName);


                //        PlayerAnimator.SetBool("CollectItem", true); // play animation
                //        if (ObjFunction.InteractingSound != null)
                //        {
                //            ObjFunction.InteractingSound.Play();
                //        }
                //        if (ObjFunction.ObjAppear != null)
                //        {
                //            ObjFunction.ObjAppear.SetActive(true);
                //        }
                //        if (ObjFunction.destroy == true)
                //        {
                //            Destroy(collision.gameObject);
                //        }
                //        a = ObjFunction.DialogueTag;
                //        StartCoroutine(ShowText());
                //        StopCoroutine(ShowText());
                //        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
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
        PlayerAnimator.SetBool("CollectUp", false);
        PlayerAnimator.SetBool("CollectDown", false);
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
        PlayerAnimator.SetBool("CollectUp", false);
        PlayerAnimator.SetBool("CollectDown", false);
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
