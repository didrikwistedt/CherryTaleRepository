using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_EagleKillbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().IsFalling() == true)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1000f));
                gameObject.GetComponentInParent<Enemy_EagleDestroy>().KillMe();
                
                Invoke("RespawnEagle", 10f);
            }
        }
    }

    public void RespawnEagle()
    {
        gameObject.GetComponentInParent<SpriteRenderer>().enabled = true;
    }



}

