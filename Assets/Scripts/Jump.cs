using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Jump System")] //serialized fields are similar to public but cannot be accessed by other scripts
    [SerializeField] float jumpTime = 0.35f;
    [SerializeField] int jumpPower = 10;
    [SerializeField] float fallMultiplier = 4f;
    [SerializeField] float jumpMultiplier = 3f;
    private Animator animator;


    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;


    bool isJumping;
    float jumpCounter;


    private void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (Input.GetButton("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
            

        }

        if(rb.velocity.y > 0 && isJumping)
        {
            animator.SetTrigger("startJump");
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) { isJumping = false; }

            float t = jumpCounter / jumpTime;
            float currentJump = jumpMultiplier;

            if (t > 0.5f)
            {
                currentJump = jumpMultiplier * (1 - t);
            }

            rb.velocity += vecGravity * currentJump * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;

            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
            }
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.19f,0.3f),CapsuleDirection2D.Horizontal,0,groundLayer);
    }
}