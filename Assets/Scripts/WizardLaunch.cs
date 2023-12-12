using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLaunch : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public GameObject chargedProjectile;
    public float chargeSpeed;
    public float chargeTime;
    public bool isCharging;
    public Animator playerAnimator;
    public float shoottime;
    public float shootcounter;

    // Start is called before the first frame update
    void Start()
    {
        shootcounter = shoottime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2") && chargeTime < 5)
        {
            playerAnimator.SetTrigger("largeFire");
            isCharging = true;
            if (isCharging == true)
            {
                
                chargeTime += Time.deltaTime * chargeSpeed; //this will count while the mouse is being held down
            }
        }
        if (Input.GetButtonDown("Fire1") && shootcounter <= 0)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            chargeTime = 0;
            shootcounter = shoottime;
        }
        
        else if(Input.GetButtonUp("Fire2") && chargeTime >= 5)
        {
            ReleaseCharge();
        }
        shootcounter -= Time.deltaTime;
    }

    void ReleaseCharge()
    {
        Instantiate(chargedProjectile, firePoint.position, firePoint.rotation);
        isCharging = false;
        chargeTime = 0;
    }
}
