using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 50f;

    [SerializeField]
    private Camera playerCamera;

    private void Update()
    {
        float mouseXDelta = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYDelta = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.Rotate(transform.up, mouseXDelta);
    }
}
