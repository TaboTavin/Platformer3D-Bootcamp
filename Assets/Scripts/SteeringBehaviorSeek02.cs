using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorSeek02 : MonoBehaviour
{
    public Transform player;
    public float seekRange = 10f;
    public float avoidRange = 5f;
    public float speed = 5f;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        // Comprobrar si el jugador esta dentro del rango de busqueda.
        if (Vector3.Distance(transform.position, player.position) <= seekRange)
        {
            // Calcular la dir hacia el jugador.
            Vector3 playerDirection = player.position - transform.position;

            // RayCast para evitar obstaculos.
            RaycastHit hit;
            if(Physics.Raycast(transform.position, playerDirection, out hit, avoidRange))
            {
                // Si el agente encuentra un obstaculo
                // Calcular una nueva direccion de evasion.

                //Vector3 avoidDirection = Vector3.Reflect(playerDirection, hit.normal).normalized;
                targetPosition = transform.position * avoidRange;
            }

            else
            {
                targetPosition = player.position;
            }

            Debug.DrawRay(transform.position, playerDirection.normalized * avoidRange, Color.green);

        }

        // Mover al enemigo hacia la pos.
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
