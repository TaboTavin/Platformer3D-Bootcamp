using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    // Player
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float jumpForce = 5f;
    public float verticalSpeed;

    private CharacterController characterController;
    //private Animator animator;
    private bool isGrounded;

    //Camera
    public Transform cameraTransform;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Tocando Piso ?
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Player Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Camera Movement
        Vector3 foward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        foward.y = 0f;
        right.y = 0f;

        foward.Normalize();
        right.Normalize();

        Vector3 moveDirection = foward * moveVertical + right * moveHorizontal;

        // Mover el personaje mientras este tocando el piso
        if(isGrounded)
        {
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalSpeed = jumpForce;
        }

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // Gravedad
        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        // Movimiento vertical
        Vector3 verticalMovement = new Vector3(0f, verticalSpeed, 0f);
        characterController.Move(verticalMovement * Time.deltaTime);

        if(isGrounded && verticalSpeed < 0f)
        {
            verticalSpeed = 0f;
        }

    }
}
