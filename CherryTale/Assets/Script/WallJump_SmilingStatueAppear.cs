using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump_SmilingStatueAppear : MonoBehaviour
{
    public Animator animator;
    public bool smilingStatueAppearTrigger = false;
    [SerializeField] private AudioSource animationStatueAudioSource;
    [SerializeField] private AudioClip animationStatueClip;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("SmilingStatueAppearTrigger", smilingStatueAppearTrigger);
    }

    public void SmilingStatueAppear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        smilingStatueAppearTrigger=true;
        animationStatueAudioSource.PlayOneShot(animationStatueClip);
        Invoke("DestroyAppear", 0.417f);
    }
    
    public void DestroyAppear()
    {
        Destroy(gameObject);
    }


}
