//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    public bool destroy; //Check to destroy object after pick
//    public AudioClip PickingSound; //Play when pick
//    public string ItemName; //Name Item to add in inventory
//    public Sprite ItemImage; //Sprite Item
//    public int DialogueTag; //Dialogue string Number

//    //เงื่อนไข
//    public bool select = false; //Check if to pick up or not
//    public string ItemToUse; //Use item to pick up

//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.gameObject.GetComponent<PickObj>() != null && collision.gameObject.GetComponent<PickObj>().select)
//        {
//            PuzzleObject ObjPick = collision.gameObject.GetComponent<PuzzleObject>(); //Call script
//            AudioSource PlayerAudio = gameObject.GetComponent<AudioSource>(); //Call audio source
//            PlayerAudio.clip = ObjPick.PickingSound;//Assign sound clip

//            if (ObjPick.ItemToUse == "")//If no item require
//            {
//                target = gameObject.transform.position;
//                PlayerAnimator.SetBool("CollectItem", true);
//                if (ObjPick.ObjectPicked != "")
//                {
//                    Item tmp = new Item();
//                    tmp.image = ObjPick.ItemImage;
//                    tmp.ItemName = ObjPick.ItemName;
//                    Inventory.Add(ObjPick.ObjectPicked);
//                    Innventory.Add(tmp);
//                    InvenSize++;
//                    if (ObjPick.PickingSound != null)
//                    {
//                        PlayerAudio.Play();
//                        Debug.Log("Sound");
//                    }
//                    if (ObjPick.InvenItem != null)
//                        ObjPick.InvenItem.SetActive(true);
//                }

//                a = ObjPick.DialogueTag;
//                StartCoroutine(ShowText());
//                ObjPick.select = false;
//                if (ObjPick.destroy == true)
//                {
//                    Destroy(collision.gameObject);
//                }
//                StopCoroutine(ShowText());
//            }
//            else
//            {
//                for (int i = 0; i < InvenSize; i++)
//                {
//                    if (ObjPick.ItemToUse == Inventory[i])
//                    {
//                        target = gameObject.transform.position;
//                        PlayerAnimator.SetBool("CollectItem", true);
//                        Item tmp = new Item();
//                        tmp.image = ObjPick.ItemImage;
//                        tmp.ItemName = ObjPick.ItemName;
//                        Inventory.Add(ObjPick.ObjectPicked);
//                        Innventory.Add(tmp);
//                        InvenSize++;
//                        if (ObjPick.PickingSound != null)
//                        {
//                            Debug.Log("Sound");
//                            PlayerAudio.Play();
//                        }
//                        a = ObjPick.DialogueTag;
//                        if (ObjPick.InvenItem != null)
//                            ObjPick.InvenItem.SetActive(true);
//                        if (ObjPick.UseItem != null)
//                        {
//                            Destroy(ObjPick.UseItem);
//                        }
//                        if (ObjPick.UseItem2 != null)
//                        {
//                            Destroy(ObjPick.UseItem2);
//                        }
//                        StartCoroutine(ShowText());
//                        if (ObjPick.destroy == true)
//                        {
//                            Destroy(collision.gameObject);
//                        }
//                        StopCoroutine(ShowText());
//                        break;
//                    }
//                }
//            }
//        }
//    }
//}
