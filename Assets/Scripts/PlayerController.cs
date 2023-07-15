using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

   

    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Verficar que el juagdor este tocando el piso
        isGrounded = Physics.Raycast(groundCheck.position, -Vector3.up, 0.1f, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular direccion de movimiento
        moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Debug.DrawRay(groundCheck.position, -Vector3.up * 0.1f, Color.red);

    }

    private void FixedUpdate()
    {
        // Aplicar movimiento en la direccion calculada
        rb.velocity = moveDirection * moveSpeed;
    }
}
