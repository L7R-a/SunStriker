using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 5;

    private float timer;
    private int currentEnemyCount;

    private void Start()
    {
        timer = spawnInterval;
        currentEnemyCount = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        currentEnemyCount++;
    }

    public void EnemyDestroyed()
    {
        if (currentEnemyCount > 0)
            currentEnemyCount--;
    }
}