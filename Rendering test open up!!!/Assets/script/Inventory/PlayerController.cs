using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;
    public float Speed = 2.0f;
    public Inventory inventory;
    public ItemSelect Hold;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        Hold = GetComponent<ItemSelect>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        InnventoryItem item = hit.collider.GetComponent<InnventoryItem>();
        if(item != null)
        {
            inventory.AddItem(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
