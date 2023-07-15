using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Referencia a la pos del jugador.
    public Vector3 offSet = new Vector3(0f, 2f, -5f); // OffSet de la posicion de la camara con respecto al jugador.
    public float smoothSpeed = 0.05f; // Velocidad de suavizado del movimiento de la camara.

    public float rotationSpeed = 2f;
    //private float rotationX = 0f;

    private float mouseX; // Movimiento Horizontal del mouse.
    private float mouseY; // Movimiento Vertical del mouse.
    

    private void Start()
    {
        offSet = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position; // Calcula la pos deseada de la camara sumando el offset deseado.

        // Actualiza la pos del jugador.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Camara simpre voltea al jugador.
        transform.LookAt(player);

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // Limitamos la rotacion vertical de la camara
        mouseY = Mathf.Clamp(mouseY, -2f, 45f);

        // Calcular la rotacion del jugador y de la camara.
        Quaternion playerRotation = Quaternion.Euler(0f, mouseX, 0f);
        Quaternion cameraRotation = Quaternion.Euler(mouseY, mouseX, 0f);

        // Aplicar rotacion al jugador. 
        player.rotation = playerRotation;

        // Aplicar la rotacion de la camara alrededor del jugador.
        transform.position = player.position + playerRotation * offSet;
        transform.rotation = cameraRotation;
    }
}
