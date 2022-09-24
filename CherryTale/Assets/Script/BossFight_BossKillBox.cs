using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight_BossKillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().IsFalling() == true)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1000f));
                gameObject.GetComponentInParent<BossFight_BossState>().DoHarm(1);

            }
        }
    }
}