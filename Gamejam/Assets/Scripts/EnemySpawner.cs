using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialEnemyCount = 5;
    public float spawnInterval = 1.5f;
    public float spawnRadius = 5f;
    public float enemySpeedIncrease = 0.5f;
    public GameObject player;


    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Spawn an enemy within a random position in the spawn radius
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        EnemyController enemyController = newEnemy.GetComponent<EnemyController>();

        if (enemyController != null && player != null)
        {
            enemyController.SetPlayer(player);
        }
    }

    public void IncreaseEnemies()
    {
        initialEnemyCount++;
        enemySpeedIncrease += 0.7f;
    }

    public void MultiplySpawnRate()
    {
        CancelInvoke("SpawnEnemy");
        if (spawnInterval > 0.01f)
        {
            spawnInterval -= 0.3f;
        }
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }
}
