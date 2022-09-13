using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Speed : MonoBehaviour
{

    private float multiplyBy = 1.5f;

    private PlayerMovement playerMovement;

    private bool isCollected = false;

    [SerializeField] private AudioSource powerUpGemAudioSource;
    [SerializeField] private AudioClip powerUpGemClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().SetBool("IsCollected", isCollected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (playerMovement == null)
            {
               playerMovement = collision.GetComponent<PlayerMovement>();
            }
             
            playerMovement.SetNewMovementSpeed(multiplyBy);
            isCollected = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            powerUpGemAudioSource.PlayOneShot(powerUpGemClip);
            Invoke("DestroyGem", 0.333f);
        }

    }

    public void DestroyGem()
    {
        Destroy(gameObject);
    }

}
