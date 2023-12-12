using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private Movement playerMovement;
    private PlayerHealth playerHealth;
    public int damage = 2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player is active
            if (collision.gameObject.activeSelf)
            {
                // Get the Movement and PlayerHealth scripts from the player GameObject
                playerMovement = collision.gameObject.GetComponent<Movement>();
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

                playerMovement.KBCounter = playerMovement.KBTotalTime;
                if (collision.transform.position.x <= transform.position.x) //if the position of the collided 'transform' is less than the player transform - set knocked from right to true
                {
                    playerMovement.KnockFromRight = true;
                }
                if (collision.transform.position.x > transform.position.x) // vice versa for when the collided object hits from the left
                {
                    playerMovement.KnockFromRight = false;
                }
                playerHealth.takeDamage(damage);
            }
        }
    }
}
