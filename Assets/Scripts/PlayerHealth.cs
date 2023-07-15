using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Salud Maxima del jugador
    public int maxHealth = 100;
    // Salud actual del jugador
    public int currentHealth;

    private void Start()
    {
        // Inicializamos la salud actual del jugador.
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Restar una cantidad x de dano al jugador
        currentHealth -= damageAmount;

        // Revisamos si el jugador sigue vivo.
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void RecoverHealth(int recoverAmount)
    {
    
        if(currentHealth <= 100)
        {
            currentHealth += recoverAmount;
        }

    }

    private void Die()
    {
        // Respawn a ultimo check point.
    }
}
