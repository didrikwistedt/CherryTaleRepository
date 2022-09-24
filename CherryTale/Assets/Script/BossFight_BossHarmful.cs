using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight_BossHarmful : MonoBehaviour
{

    public int damage =1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().isGrounded ==true)
            {
                Invoke("BossDoHarm", 0.5f);
            }
            
        }
    }

    public void BossDoHarm()
    {
        GameObject.Find("PlayerFox").GetComponent<PlayerState>().DoHarm(damage);
    }
    

}
