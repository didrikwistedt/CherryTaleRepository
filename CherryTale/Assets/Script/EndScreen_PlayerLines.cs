using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen_PlayerLines : MonoBehaviour
{

    public AudioSource playerLineAudioSource;
    public AudioClip playerLineClip;
    public AudioClip intermissionClip;

    void Start()
    {
        Invoke("PlayerLine1Trigger", 1f);
    }

    public void PlayerLine1Trigger()
    {
        gameObject.transform.Find("PlayerLine1").GetComponent<Text>().enabled = true;
        playerLineAudioSource.PlayOneShot(playerLineClip);
        Invoke("PlayerLine2Trigger", 4f);
    }

    public void PlayerLine2Trigger()
    {
        gameObject.transform.Find("PlayerLine1").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("PlayerLine2").GetComponent<Text>().enabled = true;
        playerLineAudioSource.PlayOneShot(playerLineClip);
        Invoke("PlayerLine3Trigger", 4f);
    }

    public void PlayerLine3Trigger()
    {
        gameObject.transform.Find("PlayerLine2").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("PlayerLine3").GetComponent<Text>().enabled = true;
        playerLineAudioSource.PlayOneShot(playerLineClip);
        Invoke("Intermission", 4f);
    }

    public void Intermission()
    {
        gameObject.transform.Find("PlayerLine3").GetComponent<Text>().enabled = false;
        playerLineAudioSource.PlayOneShot(intermissionClip);
        Invoke("PlayerLine1Trigger", 10f);
    }

}
