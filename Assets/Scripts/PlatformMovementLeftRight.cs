using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementLeftRight : MonoBehaviour
{
    public float speed = 2f;
    public float movementRange = 5f;

    private Vector3 initialPosition;
    private float movementDirection = 1f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calcular el desplazminto
        float movement = speed * Time.deltaTime * movementDirection;

        // Mover la plataforma hacia la direcion de movimeinto.
        transform.Translate(Vector3.right * movement);

        // Comprobar si se alcanzaron los limites del rango de movimiento.
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= movementRange / 2f)
        {
            // Cambiar la direcion de movimiento.
            movementDirection *= -1f;
        }
    }
}
