using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorSeek : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float maxSeekDistance = 10f;
    public float raycastLength = 15f;

    // Capa de obstaculos que el raycast debe evitar.
    public LayerMask obstacleLayer; 


    private void Update()
    {
        if(target != null)
        {
            // Calcular la direccion hacia el target.
            Vector3 dirrection = (target.position - transform.position).normalized;

            //Dibujar RayCast
            Debug.DrawRay(transform.position, dirrection * raycastLength, Color.green);

            // Comprobrar si el target esta dentro del rango de busqueda
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if(distanceToTarget <= maxSeekDistance)
            {
                // Verificar que esta tocando el raycast.
                RaycastHit hit;

                if(Physics.Raycast(transform.position,dirrection, out hit, raycastLength, obstacleLayer))
                {
                    Debug.DrawRay(transform.position, dirrection * hit.distance, Color.red);
                }
                else
                {
                    // Traslado el agente hacia el target
                    transform.Translate(dirrection * speed * Time.deltaTime);
                }
                
            }
        }
    }
}
