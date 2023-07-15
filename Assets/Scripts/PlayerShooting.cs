using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float shootingForce = 10f;

    private ObjectPool projectilePool;

    private void Start()
    {
        projectilePool = new ObjectPool(projectilePrefab);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Obetiene un proyectile del pool
            GameObject projectile = projectilePool.Get();

            projectile.transform.position = projectileSpawnPoint.position;
            projectile.transform.rotation = projectileSpawnPoint.rotation;

            projectile.SetActive(true);

            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = projectileSpawnPoint.forward * shootingForce;
        }
    }
}
