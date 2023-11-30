using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Transform target;
    public float padding = 1.0f; 

    void Start()
    {
        if (target != null)
        {
            AdjustCameraToTarget();
            LookAtTarget();
        }
        else
        {
            Debug.LogError("Target not assigned in CameraFocus script.");
        }
    }

    void AdjustCameraToTarget()
    {
        Camera mainCamera = Camera.main;

        // Calculate the distance from the camera to the target
        float distance = Mathf.Abs(mainCamera.transform.position.z - target.position.z);

        // Calculate the size based on the target's bounds and the camera's aspect ratio
        float targetSize = Mathf.Max(
            target.GetComponent<Renderer>().bounds.size.x / 2f,
            target.GetComponent<Renderer>().bounds.size.y / 2f
        );

        
        targetSize += padding;

        float targetOrthographicSize = targetSize / mainCamera.aspect;

        // Set the camera's orthographic size
        mainCamera.orthographicSize = targetOrthographicSize;

   
        mainCamera.transform.position = new Vector3(target.position.x, target.position.y, mainCamera.transform.position.z);
    }

    void LookAtTarget()
    {
        transform.LookAt(target);
    }
}