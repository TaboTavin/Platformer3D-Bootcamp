using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{


    
    private void OnTriggerEnter(Collider other)
    {

        // Comprobar si el objeto que colisiono es el jugador
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null)
        {
            if(PowerUp.sharedInstance.powerUpActive)
            {
                playerHealth.TakeDamage(EnemyManager.sharedInstance.damageAmount[0]);
            }

            else
            {
                playerHealth.TakeDamage(EnemyManager.sharedInstance.damageAmount[3]);
            }
            
        }
    }
}
