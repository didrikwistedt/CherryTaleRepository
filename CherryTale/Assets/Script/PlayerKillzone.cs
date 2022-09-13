using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillzone : MonoBehaviour
{

    [SerializeField] private AudioSource killzoneAudioSource;
    [SerializeField] private AudioClip killzoneAudioClip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().Respawn();
            killzoneAudioSource.PlayOneShot(killzoneAudioClip);
        }
    }
}
