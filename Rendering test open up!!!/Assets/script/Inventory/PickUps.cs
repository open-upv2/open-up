﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PickUps : MonoBehaviour
//{

//    private Innventory inventory;
//    // Start is called before the first frame update
//    void Start()
//    {
//        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Innventory>();
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if(other.CompareTag("Player"))
//        {
//            for (int i = 0; i < inventory.slots.Length; i++)
//            {
//                if(inventory.isFull[i] == false)
//                {
//                    inventory.isFull[i] = true;
//                    break;
//                }
//            }
//        }
//    }
//}
