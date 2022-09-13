using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") ==true)
        {
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
        }
    }
}
