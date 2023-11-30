using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint; // need to set this to whichever character's launchpoint is active

    public float shootTime;
    public float shootCounter;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity); // quaternion.identity just takes on whatever default rotation your sprite has
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}
