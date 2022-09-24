using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    [SerializeField] GameObject CheckpointTaken;
    [SerializeField] private AudioSource CheckpointAudioSource;
    [SerializeField] private AudioClip CheckpointTakenAudioClip;

    void Start()
    {
        CheckpointTaken.SetActive(false);

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") ==true)
        {
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
            CheckpointTaken.SetActive(true);
            CheckpointAudioSource.PlayOneShot(CheckpointTakenAudioClip);
            Invoke("InactivateAudio", 0.7f);
        }
    }

    public void InactivateAudio()
    {
        CheckpointAudioSource.enabled = false;
    }

}
