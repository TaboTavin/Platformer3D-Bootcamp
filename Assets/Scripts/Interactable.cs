using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public void Interact()
    {
        // Acciones que ocurren con el objecto que se interactua.
        Debug.Log("Interactuando con: " + gameObject.name);
    }

    public void PickUp()
    {
        // Animacion
    }
}
