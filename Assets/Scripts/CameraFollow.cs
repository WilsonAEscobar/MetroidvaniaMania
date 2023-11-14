using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f; // speed that the camera will follow at.
    public float yOffset =1f; //
    private Transform target;

    void Start()
    {
        // Find the initially active character based on the tag
        FindActiveCharacter();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
        }
        else
        {
            // If target is null, try to find the active character again
            FindActiveCharacter();
        }
    }

    void FindActiveCharacter()
    {
        // Find the active character based on the tag
        GameObject activeCharacter = GameObject.FindGameObjectWithTag("Player");

        if (activeCharacter != null)
        {
            target = activeCharacter.transform;
        }
        else
        {
            Debug.LogWarning("No active character found with tag 'Player'");
        }
    }
}
