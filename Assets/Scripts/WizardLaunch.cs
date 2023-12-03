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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2") && chargeTime < 5)
        {
            isCharging = true;
            if (isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed; //this will count while the mouse is being held down
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            chargeTime = 0;
        }
        else if(Input.GetButtonUp("Fire2") && chargeTime >= 5)
        {
            ReleaseCharge();
        }
    }

    void ReleaseCharge()
    {
        Instantiate(chargedProjectile, firePoint.position, firePoint.rotation);
        isCharging = false;
        chargeTime = 0;
    }
}
