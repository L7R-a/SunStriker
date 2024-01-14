using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public int maxEnemies = 5;

    public BasicEnemy enemyScript;
    public GameObject enemy;

    private float timer;
    public int currentEnemyCount;

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
        enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyScript = enemy.GetComponent<BasicEnemy>();
    }
    
}