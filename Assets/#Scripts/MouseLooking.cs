using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
    [SerializeField] public Transform planeBody;
    public Vector3 offset;
    public float smoothedSpeed = 0.123f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = planeBody.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothedSpeed);
        transform.position = smoothedPosition;

        transform.rotation = planeBody.rotation;

        transform.LookAt(planeBody);
    }
}
