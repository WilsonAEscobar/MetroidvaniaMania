using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : MonoBehaviour
{
    private Transform player;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.transform;
        attackPlayer();
    }

    private void attackPlayer()
    {
        float distPlayer = Vector2.Distance(transform.position, player.position);
        if (distPlayer <= 1f)
        {
            animator.SetTrigger("StartAttack");
        }
    }
}