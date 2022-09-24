using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight_BossState : MonoBehaviour
{
    public int healthPoints = 5;
    [SerializeField] private AudioSource bossHurtAudioSource;
    [SerializeField] private AudioClip bossHurtAudioClip;
    [SerializeField] private AudioClip bossDeathAudioClip;
    [SerializeField] private AudioClip bossVictoryAudioClip;

    public void DoHarm(int doHarmByThisMuch)
    {
        if (healthPoints > 0)
        {
            healthPoints -= doHarmByThisMuch;
            gameObject.GetComponent<Animator>().SetTrigger("TakeHit");
            bossHurtAudioSource.PlayOneShot(bossHurtAudioClip);
        }
        

        else if (healthPoints <= 0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            Invoke("DestroyBoss", 2.6f);
            bossHurtAudioSource.PlayOneShot(bossDeathAudioClip);
        }
    }


    public void DestroyBoss()
    {
        gameObject.GetComponentInChildren<BossFight_BossAppearAnimation>().BossAppear();
        Invoke("SpriteRendererOff", 0.2f);
    }

    public void SpriteRendererOff()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Invoke("CompleteBoss", 0.2f);
    }

    public void CompleteBoss()
    {
        GameObject.Find("BossFightMusic").GetComponent<AudioSource>().enabled = false;
        bossHurtAudioSource.PlayOneShot(bossVictoryAudioClip);
        Invoke("DestroySprite", 2.7f);
    }

    public void DestroySprite()
    {
        Destroy(gameObject);
        
    }

}
