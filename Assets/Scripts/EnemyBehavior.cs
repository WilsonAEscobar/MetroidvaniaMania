using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 2f;
    private float leftDistance = 3f; // Maximum distance to the left from the initial position
    private float rightDistance = 3f; // Maximum distance to the right from the initial position
    private float groundCheckDistance = 3f;

    private int direction = 1;
    private Vector2 initialPosition;
    private Animator animator;

    void Start()
    {
        // Store the initial position of the sprite
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.SetTrigger("StartWalk");
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Ground"));

        if (isGrounded)
        {
            // Use Rigidbody2D to move the GameObject
            GetComponent<Rigidbody2D>().velocity = new Vector2(direction * speed, GetComponent<Rigidbody2D>().velocity.y);
        }

        // Calculate the boundaries based on the initial position
        float leftBound = initialPosition.x - leftDistance;
        float rightBound = initialPosition.x + rightDistance;

        // Check if the enemy is out of bounds and change direction
        if (transform.position.x > rightBound && direction == 1)
        {
            FlipCharacter();
        }
        else if (transform.position.x < leftBound && direction == -1)
        {
            FlipCharacter();
        }
    }

    void FlipCharacter()
    {
        // Flip the character by adjusting the scale
        Vector2 newScale = transform.localScale;
        newScale.x *= -1; // Flip the x-scale
        transform.localScale = newScale;

        // Change the direction
        direction *= -1;

    }
}