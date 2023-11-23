using UnityEngine;

public class EnemyScript : MonoBehaviour //Work in progress
{
    private Vector2 playerPosition;
    private Animator animator;
    private float leftBoundary;  
    private float rightBoundary;
    private Vector2 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            playerPosition = playerObject.transform.position;
        }
        else
        {
            Debug.LogError("Player not found!");
        }

        animator = GetComponent<Animator>();
        leftBoundary = initialPosition.x - 2.9f;
        rightBoundary = initialPosition.x + 2.9f;
    }

    void Update()
    {


        
        float attackRange = 2f;
        if (Vector2.Distance(transform.position, playerPosition) < attackRange)
        {
            animator.SetTrigger("Attack");
        }

    }

    

}