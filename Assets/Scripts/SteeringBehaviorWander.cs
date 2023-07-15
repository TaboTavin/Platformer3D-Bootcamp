using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviorWander : MonoBehaviour
{
    public float speed = 5f;
    public float wanderDistance = 10f;
    public float wanderRadius = 2f;
    
    // Timer para cambiar el target position.
    public float maxTimeToReachTarget = 5f;
    private float timer;

    public GameObject targetPositionPoint;

    private Vector3 targetPosition;

    private void Start()
    {
        targetPosition = GetRandomPointInSphere() + transform.position;
        timer = 0f;
    }

    private void Update()
    {
        // Verificar que se llego a la posicion destino.
        if(Vector3.Distance(transform.position, targetPosition) <= 0.5f)
        {
            // Si se llego, obetener una nueva posicion de destino aleatoria.
            targetPosition = GetRandomPointInSphere() + transform.position;
            timer = 0f;
        }

        else
        {
            timer += Time.deltaTime;

            if(timer >= Time.deltaTime)
            {
                targetPosition = GetRandomPointInSphere() + transform.position;
                timer = 0f;
            }
        }

        // Calcular la dirrecion hacia la posicion de destino.
        Vector3 direction = (targetPosition - transform.position).normalized;

        //Mover al agente a la nueva dire.
        transform.Translate(direction * speed * Time.deltaTime);

        // Update del punto nuevo en gizmos.
        targetPositionPoint.transform.position = targetPosition;

    }

    private Vector3 GetRandomPointInSphere()
    {
        Vector3 randomPoint = Random.insideUnitSphere * wanderRadius;
        randomPoint.y = 0f;

        return randomPoint;
    }

    // Metodo que dibuja el circulo de vagar del enemigo/agente
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si la colision es con una pared.
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Obtener una nueva posicion de destino aleatoria
            targetPosition = GetRandomPointInSphere() + transform.position;
        }
    }
}
