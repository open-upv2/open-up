using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public PlayerController player;
    public Animator playerAni;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D collision)
    {
        player.transform.Translate((-0.1f), 0.0f, 0.0f);
        player.target = player.transform.position;
        playerAni.SetBool("Walk", false);
    }

}
