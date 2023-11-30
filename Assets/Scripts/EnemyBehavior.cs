using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackRange;
    private Animator animator;
    private Vector2 initialPosition;
    private float leftDistance = 6f; // Maximum distance to the left from the initial position
    private float rightDistance = 6f; // Maximum distance to the right from the initial position
    public GameObject playerPrefab;

    public int maxHealth = 10;
    public int health;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //sets rb to the rigidbody on our enemy sprite - set it in the unity editor
     
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        health = maxHealth;


    }

    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        float leftBound = initialPosition.x - leftDistance;
        float rightBound = initialPosition.x + rightDistance;
        //Check the distance to the player
        float distToPlayer = Vector2.Distance(transform.position, player.position); //returns the distance between a and b in parameters / transform.position is the enemies position

        if (distToPlayer < agroRange && transform.position.x > leftBound && transform.position.x < rightBound)
        {
            //code to chase player
            ChasePlayer();
            AttackPlayer();
        }
        else
        {
            StopChasingPlayer();

        }
    }

    private void StopChasingPlayer()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer > agroRange)
        {
            // Player is outside agro distance, allow flipping
            if (transform.position.x < initialPosition.x - 0.1f)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
            }
            else if (transform.position.x > initialPosition.x + 0.1f)
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                animator.SetTrigger("GoIdle");
            }
        }
       else if (distToPlayer < agroRange)
        {
            //Player is still within agro distance, don't flip
            rb.velocity = new Vector2(0, 0);
            animator.SetTrigger("GoIdle"); 
            
        }  
    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x) //this means we are on the left of the player and want to move right towards the player 
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, 0); // will move -movespeed to the player (left)
            transform.localScale = new Vector2(-1, 1);
        }
        animator.SetTrigger("StartWalk");
    }

    private void AttackPlayer()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer <= attackRange)
        {
            // Attack the player
            animator.SetTrigger("StartAttack");
        }
        /*else
        {
            animator.SetTrigger("StartWalk");
        }*/
    }
 
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}