using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight_BossAppearAnimation : MonoBehaviour
{
    
    [SerializeField] private AudioSource bossAppearAudioSource;
    [SerializeField] private AudioClip bossAppearAudioClip;


    public void BossAppear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        bossAppearAudioSource.PlayOneShot(bossAppearAudioClip);
        Invoke("DestroyAppear", 0.4f);
    }

    public void DestroyAppear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
