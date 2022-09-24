using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] private AudioSource playerTalkAudioSource;
    [SerializeField] private AudioClip playerTalkAudioClip;
    [SerializeField] private AudioClip MainMenuMusicAudioClip;
    [SerializeField] private GameObject PlayerFox;




    // Start is called before the first frame update
    void Start() {   
     //   gameObject.transform.GetComponent<PlayerMovement>().enabled = false;
        Invoke("EnableStartPlayerLine1", 1f);
        gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void EnableStartPlayerLine1()
    {
        //gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.transform.Find("StartPlayerLine1").GetComponent<Text>().enabled = true;
        Invoke("EnableStartPlayerLine2", 4f);
        playerTalkAudioSource.PlayOneShot(playerTalkAudioClip);
    }

    public void EnableStartPlayerLine2()
    {
       // gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = true;
        gameObject.transform.Find("StartPlayerLine2").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("StartPlayerLine3").GetComponent<Text>().enabled = true;
        Invoke("EnableStartPlayerLine3", 4f);
        playerTalkAudioSource.PlayOneShot(playerTalkAudioClip);

    }

    public void EnableStartPlayerLine3()
    {
        //gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.transform.Find("StartPlayerLine3").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("StartPlayerLine4").GetComponent<Text>().enabled = true;
        Invoke("DisableStartPlayerLine4", 5f);
        playerTalkAudioSource.PlayOneShot(playerTalkAudioClip);

    }


    public void EnableStartPlayerLine4()
    {
        //gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.transform.Find("StartPlayerLine4").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("StartPlayerLine5").GetComponent<Text>().enabled = true;
        Invoke("DisableStartPlayerLine5", 5f);
        playerTalkAudioSource.PlayOneShot(playerTalkAudioClip);

    }

    public void EnableStartPlayerLine5()
    {
        //gameObject.transform.parent.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.transform.Find("StartPlayerLine5").GetComponent<Text>().enabled = false;
        gameObject.transform.Find("StartPlayerLine4").GetComponent<Text>().enabled = true;
        Invoke("DisableStartPlayerLine", 5f);
        playerTalkAudioSource.PlayOneShot(playerTalkAudioClip);
   
    }

    public void DisableStartPlayerLine()
    {
        gameObject.transform.Find("StartPlayerLine5").GetComponent<Text>().enabled = false;
        //gameObject.transform.parent.GetComponent<PlayerMovement>().enabled = true;
        playerTalkAudioSource.PlayOneShot(MainMenuMusicAudioClip);
        playerTalkAudioSource.loop = true;
       
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
