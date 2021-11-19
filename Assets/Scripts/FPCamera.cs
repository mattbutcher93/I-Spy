using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple FP
public class FPCamera : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 50f;

    [SerializeField]
    private Transform playerCameraTransform;

    private float cameraLocalXRotation;

    private void Awake()
    {
        cameraLocalXRotation = playerCameraTransform.localRotation.eulerAngles.x;
    }

    private void Update()
    {
        float mouseXDelta = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYDelta = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;


        transform.Rotate(transform.up, mouseXDelta);

        cameraLocalXRotation = Mathf.Clamp(cameraLocalXRotation - mouseYDelta, -90f, 90f);
        playerCameraTransform.localRotation = Quaternion.Euler(cameraLocalXRotation,
                                                                playerCameraTransform.localRotation.y,
                                                                playerCameraTransform.localRotation.z);
    }
}
