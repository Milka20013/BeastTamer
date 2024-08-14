using System;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    private Enemy[] enemies;

    private void Start()
    {
        enemies = transform.GetComponentsInChildren<Enemy>();
        MarkEnemiesAsTameable();
    }

    private void MarkEnemiesAsTameable()
    {
        int tameAbleCount = 1 + Math.Max((enemies.Length / 2) - 1, 0);
        for (int i = 0; i < tameAbleCount; i++)
        {
            enemies[i].GetComponent<EnemyDeathManager>().MarkAsTameable();
        }
    }
}
