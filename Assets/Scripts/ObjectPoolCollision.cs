using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolCollision : MonoBehaviour
{
    //private ObjectPool objectPool;
    private List<GameObject> objectPool = new List<GameObject>();


    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        // Verificando si el objecto collisionado esta en el pool.
        if(objectPool.Contains(collidedObject))
        {
            collidedObject.SetActive(false);// Se desactiva el objecto.
        }
    }
}
