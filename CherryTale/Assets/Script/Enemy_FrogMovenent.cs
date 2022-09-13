using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FrogMovenent : MonoBehaviour
{

    public float speed = 5f;
    private float movementDirection = 1f;
    
    Rigidbody2D rigidBody2D;
    private Animator animator;

    public GameObject groundCheck;

    bool isGrounded;

    private bool isAlive = true;

    [SerializeField] private AudioSource opossumAudioSource;
    [SerializeField] private AudioClip opossumAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsAlive", isAlive);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded == true && isAlive == true) {
            Vector3 newPosition = gameObject.transform.position;
            newPosition.x += speed * Time.fixedDeltaTime * movementDirection;
            rigidBody2D.MovePosition(newPosition);
        }

        if (isAlive) { 
            CheckForGround();

            if (isGrounded == false) { 
                ChangeDirection(); 
            }
            
        }

        
    }

    private void CheckForGround() {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            ChangeDirection();
        }
    }


    private void ChangeDirection() {
        movementDirection = -movementDirection;
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = movementDirection;
        gameObject.transform.localScale = newScale;
    }

    public void KillMe()
    {

        opossumAudioSource.PlayOneShot(opossumAudioClip);
        isAlive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Vector2 killForce = new Vector2(movementDirection, 2f);

        //få den att inte falla så att explosionsanimation funkar bra
        rigidBody2D.gravityScale = 0;

        //dessa två är obetydliga med min nya dödsanimation
               //rigidBody2D.AddForce(killForce, ForceMode2D.Impulse);
               //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x , -1);

        //invoke för att enemyn ska sprängas och sedan bli destroyed
        Invoke("DestroyEnemy", 0.5f);

    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
