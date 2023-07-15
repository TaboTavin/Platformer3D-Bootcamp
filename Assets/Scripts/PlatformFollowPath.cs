using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollowPath : MonoBehaviour
{
    // Nodos del camino, que la plataforma sigue -> Game Objects Vacios.
    public Transform[] pathNodes;
    public float speed = 2f;
    public float arrivalThreshold = 0.1f;

    private int currentNodeIndex = 0;

    public Transform playerTransform;
    private bool isPlayerOnPlatform = false;

    private void Update()
    {
        if(currentNodeIndex < pathNodes.Length)
        {
            // Obetener la posicion del nodo actual al que la plataforma va avanzar.
            Vector3 targetPosition = pathNodes[currentNodeIndex].position;

            // Calcular Desplazamiento
            Vector3 movementDirection = targetPosition - transform.position;
            Vector3 movement = movementDirection.normalized * speed * Time.deltaTime;

            //Mover la plataforma.
            transform.Translate(movement);

            // Comprobar que la plataforma llego al nodo.
            if(Vector3.Distance(transform.position, targetPosition) < arrivalThreshold)
            {
                // Notificamos que vanzamos un nodo
                currentNodeIndex++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            playerTransform.parent = transform;
            isPlayerOnPlatform = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerTransform.parent = null;
            playerTransform = null;
            isPlayerOnPlatform = false;
        }
    }
}
