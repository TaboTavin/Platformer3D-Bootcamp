using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    //Distancia maxima del RayCast de intertaccion.
    public float interactionRange = 5f;
    public Text interactionText;

    private bool isInteracting;

    private void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, interactionRange))
        {
            // Verificar si el ray cast impacto con un ojbeto interactuable.
            Interactable interactable = hit.collider.GetComponent<Interactable>();


            if (interactable != null)
            {
                interactionText.gameObject.SetActive(true);
                isInteracting = true;
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
               
            }

            else
            {
                interactionText.gameObject.SetActive(false);
                isInteracting = false;
            }

            // Actualizar el texto de ineracion.
            if(isInteracting)
            {
                interactionText.text = "Presiona E para interactuar";
            }

            else
            {
                interactionText.text = "";
            }

            Debug.DrawRay(rayOrigin, rayDirection * interactionRange, Color.red);
        }
    }
}
