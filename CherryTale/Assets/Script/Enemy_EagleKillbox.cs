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
                gameObject.GetComponentInParent<Enemy_EagleDestroy>().KillMe();
            }
        }
    }
}

