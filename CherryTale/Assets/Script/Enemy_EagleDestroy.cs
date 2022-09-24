using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_EagleDestroy : MonoBehaviour
{

    private Animator animator;
    public bool isAlive = true;
    [SerializeField] private AudioSource eagleAudioSource;
    [SerializeField] private AudioClip eagleAugioClip;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsAlive", isAlive);
    }

    public void KillMe()
    {
        isAlive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<ElevatorMovement>().speed = 0f;
        eagleAudioSource.PlayOneShot(eagleAugioClip);
        Invoke("DestroyEnemy", 0.5f);
    }

    public void DestroyEnemy()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Invoke("EagleRespawn", 10f);
    }

    public void EagleRespawn()
    {
        isAlive = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<ElevatorMovement>().speed = 2f;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }


}
