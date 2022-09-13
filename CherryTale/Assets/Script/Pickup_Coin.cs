using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;

    private bool isCollected = false;

    private void Update()
    {
        gameObject.GetComponent<Animator>().SetBool("IsCollected", isCollected);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            isCollected = true;
            collision.GetComponent<PlayerState>().CoinPickup();
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Invoke("DestroyCoin", 0.333f);
            audioSource.PlayOneShot(pickupClip);
        }
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }

}
