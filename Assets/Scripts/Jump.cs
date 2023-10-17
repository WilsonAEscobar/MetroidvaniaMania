using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float jumpSpeed = 10;

    private bool onGround = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            Vector2 jumpMovement = new(jumpSpeed, jumpForce);
            rb.velocity = jumpMovement * jumpSpeed;

            transform.Translate(jumpMovement);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
