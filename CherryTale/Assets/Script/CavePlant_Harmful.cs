using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePlant_Harmful : MonoBehaviour
{
    public int damage = 1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().DoHarm(damage);
        }
    }



}
