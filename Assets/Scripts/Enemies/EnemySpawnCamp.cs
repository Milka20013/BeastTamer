using UnityEngine;

public class EnemySpawnCamp : MonoBehaviour
{
    // To-do: enemy weights and float enemy count?
    [SerializeField] private EnemyBlueprint[] enemyPrefabs;
    [SerializeField] private int enemyCount;
    [SerializeField] private GameObject enemyBrainPrefab;
    [SerializeField] private float radiusFromCenter;
    [SerializeField] private float radiusFromBrain;

    private void Start()
    {
        EnemySpawner.instance.RegisterEnemyCamp(this);
    }
    public void SpawnEnemyBrain()
    {
        Vector2 spawnPosition = Random.insideUnitCircle * radiusFromCenter;
        var enemyBrain = Instantiate(enemyBrainPrefab, spawnPosition, Quaternion.identity);
        SpawnEnemiesForBrain(enemyBrain.transform);
    }

    private void SpawnEnemiesForBrain(Transform brainTransform)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 spawnPosition = Random.insideUnitCircle * radiusFromBrain;
            Instantiate(Utilitity.RandomElement(enemyPrefabs).prefab, spawnPosition, Quaternion.identity, brainTransform);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusFromCenter);
    }
}
