using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallJumpUnlockScenario : MonoBehaviour
{

    [SerializeField] private AudioSource wallJumpScenarioAudioSource;
    [SerializeField] private AudioClip wallJumpPlayerTalkClip;
    [SerializeField] private AudioClip wallJumpStatueTalkClip;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerMovement>().movementSpeed = 0f;
            GameObject.Find("Level02Music").GetComponent<AudioSource>().enabled = false;
            Invoke("WallJumpPlayerLine1Trigger", 0.5f);
        }
    }

    public void WallJumpPlayerLine1Trigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine1").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpPlayerTalkClip);
        Invoke("WallJumpSmilingStatueAnimationTrigger", 4f);
    }

    public void WallJumpSmilingStatueAnimationTrigger()
    {
        gameObject.transform.Find("SmilingStatueAnimation").GetComponent<WallJump_SmilingStatueAppear>().SmilingStatueAppear();
        Invoke("WallJumpSmilingStatueTrigger", 0.2f);
    }


    public void WallJumpSmilingStatueTrigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine1").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("SmilingStatue").GetComponent<SpriteRenderer>().enabled = true;
        Invoke("WallJumpSmilingStatueLine1Trigger", 0.5f);
    }

    public void WallJumpSmilingStatueLine1Trigger()
    {
        GameObject.Find("PlayerFox").GetComponent<SpriteRenderer>().flipX = true;
        gameObject.transform.Find("Canvas").transform.Find("WallJumpStatueLine1").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpStatueTalkClip);
        Invoke("WallJumpPlayerLine2Trigger", 4f);
    }

    public void WallJumpPlayerLine2Trigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpStatueLine1").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine2").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpPlayerTalkClip);
        Invoke("WallJumpSmilingStatueLine2Trigger", 3f);
    }

    public void WallJumpSmilingStatueLine2Trigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine2").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("Canvas").transform.Find("WallJumpStatueLine2").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpStatueTalkClip);
        Invoke("WallJumpPlayerLine3Trigger", 4f);
    }

    public void WallJumpPlayerLine3Trigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpStatueLine2").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine3").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpPlayerTalkClip);
        GameObject.Find("PlayerFox").GetComponent<SpriteRenderer>().flipX = false;
        Invoke("WallJumpSmilingStatueLine3Trigger", 4f);
    }

    public void WallJumpSmilingStatueLine3Trigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine3").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("Canvas").transform.Find("WallJumpStatueLine3").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpStatueTalkClip);
        GameObject.Find("PlayerFox").GetComponent<SpriteRenderer>().flipX = true;
        Invoke("OrbAppear", 0.5f);
        Invoke("WallJumpPlayerLine4Trigger", 4f);
    }

    public void OrbAppear()
    {
        gameObject.transform.Find("Orb").GetComponent<WallJumpUnlockOrb>().OrbAppear();
    }

    public void WallJumpPlayerLine4Trigger()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpStatueLine3").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine4").GetComponent<Text>().enabled = true;
        wallJumpScenarioAudioSource.PlayOneShot(wallJumpPlayerTalkClip);
        Invoke("WallJumpDialogueEnd", 4f);
    }

    public void WallJumpDialogueEnd()
    {
        gameObject.transform.Find("Canvas").transform.Find("WallJumpPlayerLine4").GetComponent<Text>().enabled = false;
        GameObject.Find("PlayerFox").GetComponent<PlayerMovement>().ResetMovementSpeed();
        GameObject.Find("PlayerFox").GetComponent<SpriteRenderer>().flipX = false;
        GameObject.Find("Level02Music").GetComponent<AudioSource>().enabled = true;
        Destroy(gameObject);
    }

}

