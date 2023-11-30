using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard: MonoBehaviour
{
    Animator myAnimator;
    bool facingRight = true;
    const string walk_anim = "Move";
    const string jump_anim = "Jump";
    const string attack_anim = "Attack";
    const string release_anim = "Release";
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.D))
        {
            
            if (facingRight != true)
                {
                    facingRight = true;
                    Flip();
                }
            myAnimator.SetTrigger(walk_anim);
            
            }
            if (Input.GetKeyDown(KeyCode.A))
        {
           
            if (facingRight==true)
            {
                Flip();
                facingRight = false;
            }
            myAnimator.SetTrigger(walk_anim);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            if (Input.GetKey(KeyCode.A)&&facingRight == true)
            {
                facingRight = false;
                Flip();
                myAnimator.SetTrigger(jump_anim);
            }
            if (Input.GetKeyDown(KeyCode.D) && facingRight == false)
            {
                Flip();
                facingRight = true;
                myAnimator.SetTrigger(jump_anim);
            }
            myAnimator.SetTrigger(jump_anim);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            myAnimator.SetTrigger(release_anim);

        }

        if (Input.GetMouseButton(0))
        {
            myAnimator.SetTrigger(attack_anim);

        }

    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
