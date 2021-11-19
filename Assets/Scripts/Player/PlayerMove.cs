using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Moves the player along the XZ plane using a CharacterController
[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float xMoveInput = Input.GetAxis("Horizontal");
        float zMoveInput = Input.GetAxis("Vertical");

        Vector3 moveVector = (transform.right * xMoveInput) + (transform.forward * zMoveInput);

        characterController.Move(moveVector * speed * Time.deltaTime);
    }
}
