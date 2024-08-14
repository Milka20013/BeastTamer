using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    private List<EnemySpawnCamp> enemySpawnCamps = new();

    private void Awake()
    {
        if (instance != null)
        {
            this.SingletonWarning();
        }
        instance = this;
    }
    public void RegisterEnemyCamp(EnemySpawnCamp spawnCamp)
    {
        enemySpawnCamps.Add(spawnCamp);
    }

    private void Start()
    {
        SpawnEnemies();
    }
    public void SpawnEnemies()
    {
        foreach (var camp in enemySpawnCamps)
        {
            camp.SpawnEnemyBrain();
        }
    }
}
