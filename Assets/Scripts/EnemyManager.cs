using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Enemy01,
    Enemy02,
    Enemy03
}

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager sharedInstance;

    public EnemyType enemyType;

    //Lista de valores de dano
    public List<int> damageAmount = new List<int> { 0, 25, 50, 75 };


    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;

        else
            Destroy(gameObject);
    }
    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        switch (enemyType)
        {
            case EnemyType.Enemy01:
                
                break;

            case EnemyType.Enemy02:
                
                break;

            case EnemyType.Enemy03:
                
                break;
        }
    }

}
