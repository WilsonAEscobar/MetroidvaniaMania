using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 2;
    public PlayerHealth playerHealth;
    public Movement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            // Check the type of player movement script
            playerMovement = playerObject.GetComponent<Movement>(); 
            playerHealth = playerObject.GetComponent<PlayerHealth>();

            Debug.Log("EnemyDamage script assigned to player: " + playerObject.name);
        }
        else
        {
            Debug.LogError("Player object not found in the scene!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) //anytime our enemy collides into something, this will be called
    {
       if(collision.gameObject.tag == "Player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x) //if the position of the collided 'transform' is less than the player transform - set knocked from right to true
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
