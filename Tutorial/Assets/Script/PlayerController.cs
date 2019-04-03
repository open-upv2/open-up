using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float speed = 4.0f;
    Vector3 target;

    private List<string> Inventory = new List<string>();

    public bool stay = true;
    public bool exit = true;
    public float moveSpeed;

    enum ObjectPick
    {
        Helmet = 0
    }

    string[] DialoguePick = new string[]
    {
        "Helmet",
        "Hah??"
    };

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = transform.position.y;
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PickObj>().select)
        {
            //animation.Play("");
            //yield WaitForSeconds(animation["die"].length);
            Debug.Log(collision.gameObject.GetComponent<PickObj>().Say);
            Inventory.Add("Weird Helmet");
            Debug.Log(Inventory[0]);
            Destroy(collision.gameObject);
        }

    }

}
