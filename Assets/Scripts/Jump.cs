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
            Vector3 jumpMovement = new(0.0f, 1.0f, 0.0f);
            rb.velocity = jumpMovement * jumpSpeed;
        }

        transform.Translate(rb.velocity);
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
