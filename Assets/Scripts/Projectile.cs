using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRB;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public Movement playerMovement;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        facingRight = playerMovement.facingRight;
        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (facingRight)
        {
            projectileRB.velocity = new Vector2(speed, projectileRB.velocity.y);
        }
        else
        {
            projectileRB.velocity = new Vector2(-speed, projectileRB.velocity.y); //moves arrow to left
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
