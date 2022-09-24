using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().movementSpeed = 0f;
        GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().isInCutscene = true;
        bossHurtAudioSource.PlayOneShot(bossVictoryAudioClip);
        Invoke("EndScreenTrigger", 5f);
    }

    public void EndScreenTrigger()
    {
        SceneManager.LoadScene(3);
    }

}
