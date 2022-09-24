using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BossFight_Trigger : MonoBehaviour
{

    [SerializeField] private AudioSource bossFightAudioSource;
    [SerializeField] private AudioClip bossFightPlayerTalkClip;
    [SerializeField] private AudioClip bossFightBossTalkClip;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerMovement>().movementSpeed = 0f;
            GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().isInCutscene = true;
            Invoke("BossFightPlayerLineTrigger", 0.5f);
        }
    }

    public void BossFightPlayerLineTrigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("BossFightPlayerLine").GetComponent<Text>().enabled = true;
        bossFightAudioSource.PlayOneShot(bossFightPlayerTalkClip);
        Invoke("BossFightBossAppearAnimationTrigger", 4f);
    }

    public void BossFightBossAppearAnimationTrigger()
    {
        gameObject.transform.Find("Boss").GetComponentInChildren<BossFight_BossAppearAnimation>().BossAppear();
        Invoke("BossFightBossTrigger", 0.2f);
    }

    public void BossFightBossTrigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("BossFightPlayerLine").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("Boss").GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.Find("Boss").GetComponent<Animator>().enabled = true;
        Invoke("BossFightBossLineTrigger", 1f);
    }

    public void BossFightBossLineTrigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("BossFightBossLine").GetComponent<Text>().enabled = true;
        bossFightAudioSource.PlayOneShot(bossFightBossTalkClip);
        Invoke("BossFightStart", 3f);
    }

    public void BossFightStart()
    {
        gameObject.transform.Find("Canvas").transform.Find("BossFightBossLine").GetComponent<Text>().enabled = false;
        GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().ResetMovementSpeed();
        GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().isInCutscene = false;
        GameObject.Find("BossFightMusic").GetComponent<AudioSource>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }



}
