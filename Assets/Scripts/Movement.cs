using UnityEngine;

public class Movement : MonoBehaviour
{
    private float input;
    public float speed = 8f;
    public bool flippedLeft;
    public bool facingRight;
    private Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    public LayerMask groundLayer;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }
    
    }

    private void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            rb.velocity = new Vector2(input * speed, rb.velocity.y);
        }
        else
        {

            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce); //if knocked back from the right, then move -KBforce which would be left
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce); //vice versa for if knocked back from left
            }
            KBCounter -= Time.deltaTime;
        }

        if (input < 0)
        {
            facingRight = false;
            FlipCharacter(false);
            animator.SetTrigger("Move");
        }
        else if (input > 0)
        {
            facingRight = true;
            FlipCharacter(true);
            animator.SetTrigger("Move");
        }
        else if (input == 0)
        {
            animator.SetTrigger("Idle");
        }

        if (input < 0)
        {
            FlipCharacter(false);
        }
        else if (input > 0)
        {
            FlipCharacter(true);
        }
    }

    void FlipCharacter(bool isFacingRight)
    {
        if(flippedLeft && facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = false;
        }
        if(!flippedLeft && !facingRight)
        {
            transform.Rotate(0, -180, 0);
            flippedLeft = true;
        }

    }
}