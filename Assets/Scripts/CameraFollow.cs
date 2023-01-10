using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // the object to follow
    public float smoothSpeed = 0.125f;
    public Vector2 offset;

    void LateUpdate()
    {
        // Move the camera to the target position
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y + offset.y, transform.position.z);

        // Smoothly move the camera to the target position
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Move the camera to the position with no smoothing
        transform.position = desiredPosition;
    }
}

