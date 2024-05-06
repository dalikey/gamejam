using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int initialEnemyCount = 5;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;
    public float enemySpeedIncrease = 0.5f;
    public GameObject player;

    private int currentEnemyCount;

    void Start()
    {
        currentEnemyCount = 0;
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < initialEnemyCount)
        {
            // Spawn an enemy within a random position in the spawn radius
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            EnemyController enemyController = newEnemy.GetComponent<EnemyController>();

            if (enemyController != null && player != null)
            {
                enemyController.SetPlayer(player);
            }

            currentEnemyCount++;
        }
    }

    public void IncreaseEnemies()
    {
        initialEnemyCount++;
        enemySpeedIncrease += 0.7f;
    }
}
