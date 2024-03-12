using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.instance.player.running = false;
            GameController.instance.player.canRun = false;
            GameController.instance.player.rb.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
        }
    }
}