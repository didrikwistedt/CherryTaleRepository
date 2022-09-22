using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public GameObject groundCheck;

    private bool isGrounded;

    public float movementSpeed = 2f;
    private float defaultMovementSpeed;
    private float moveDirection = 0f;
    public float jumpForce = 10f;
    private bool isFacingLeft;
    private bool isJumpPressed = false;
    private Vector3 velocity;
    public float smoothTime = 0.2f;
    public bool isHurt = false;
    [SerializeField] private LayerMask whatIsGround;

    
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private AudioClip playerJumpAudioClip;
    [SerializeField] private AudioClip playerHurtAudioClip;
    [SerializeField] private AudioClip playerPowerUpEndAudioClip;


    [Header("Wall Jump System")]
    [SerializeField] private LayerMask wallLayer;
  //  public GameObject wallCheck;
  






    // Start is called before the first frame update
    public void Start() 
    {
        defaultMovementSpeed = movementSpeed;
        isFacingLeft=false;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
        moveDirection = Input.GetAxis("Horizontal");

        if ((Input.GetKeyDown(KeyCode.Space) == true)|| (Input.GetKeyDown(KeyCode.W) == true)){
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
        }

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        animator.SetBool("IsHurt", isHurt);

    }




    private void FixedUpdate() 
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);
  


        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                isGrounded = true;
            }
        }


        Vector3 calculatedMovement = Vector3.zero;            
        float verticalVelocity = 0f;

        if (isGrounded == false) {
            verticalVelocity = rigidBody2D.velocity.y;
        }


        calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;
    }

  


    private void Move(Vector3 movement, bool isJumpPressed)
    {
        //WallJumping börjar här :)
        //Översättning för nedanför: "Om man hoppar = spelar ljud: om man dessutom hoppar och är på marken = åker uppåt; om man dessutom hoppar och är på en vägg = får en knuff uppåt och åt motsatt direction. Om man är på en vägg men inte hoppar = faller neråt."

        if (isJumpPressed) {
            playerAudioSource.PlayOneShot(playerJumpAudioClip);

            if (isGrounded) {
                rigidBody2D.AddForce(new Vector2(0f, jumpForce));
                
            } else if (onWall() == true) {
                rigidBody2D.AddForce(new Vector2(-moveDirection* jumpForce*1.6f, jumpForce*1.4f));
            }

        } else if (onWall()){
            rigidBody2D.AddForce(new Vector2(0f, -20f));
        }

        //WallJumping slutar här :(

        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, movement, ref velocity, smoothTime);


        if (movement.x > 0f && isFacingLeft == true) {
            FlipSpriteDirection(); 
        }
        
        else if (movement.x < 0f && isFacingLeft == false) {
            FlipSpriteDirection();
        }
    }

    

    private void FlipSpriteDirection() {
        spriteRenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public bool IsFalling() {
        if (rigidBody2D.velocity.y < -1f) {
            return true;
        }

        return false;
    }


    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy") == true) {
            isHurt = true;
            playerAudioSource.PlayOneShot(playerHurtAudioClip);
            Invoke("HurtAnimationEnd", 0.5f);
        }
    }

    public void HurtAnimationEnd() {
        isHurt = false;
    }

    public void ResetMovementSpeed() {
        movementSpeed = defaultMovementSpeed;
        playerAudioSource.PlayOneShot(playerPowerUpEndAudioClip);
    }

    public void SetNewMovementSpeed(float multiplyBy) {
        movementSpeed *= multiplyBy;
        Invoke("ResetMovementSpeed", 5f);
    }


    private bool onWall() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(transform.position,
            Vector3.one, 0, new Vector2(transform.localScale.x, 0), 1f, wallLayer);
        return raycastHit.collider != null;
    }
}



