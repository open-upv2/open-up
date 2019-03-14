using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    //void OnCollisionEnter()
    //{
    //   transform.Translate(10.0f, 0, 0);
    //    //Check for a match with the specified name on any GameObject that collides with your GameObject
    //    //if (collision.gameObject.name == "MyGameObjectName")
    //    //{
    //    //    //If the GameObject's name matches the one you suggest, output this message in the console
    //    //    Debug.Log("Do something here");
    //    //}

    //    ////Check for a match with the specific tag on any GameObject that collides with your GameObject
    //    //if (collision.gameObject.tag == "MyGameObjectTag")
    //    //{
    //    //    //If the GameObject has the same tag as specified, output this message in the console
    //    //    Debug.Log("Do something else here");
    //    //}
    //}
    //void OnTriggerStay(Collision collisionInfo)
    //{
    //    transform.Translate(10.0f, 0, 0);
    //    // Debug-draw all contact points and normals
    //    //foreach (ContactPoint contact in collisionInfo.contacts)
    //    //{
    //    //    Debug.DrawRay(contact.point, contact.normal, Color.white);
    //    //}
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.Translate(1.0f, 0, 0);
        Debug.Log("a");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        transform.Translate(1.0f, 0, 0);
        Debug.Log("a");
    }
}
