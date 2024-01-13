using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnRate = 10f;
    public float maxSpawnRate = 20f;
    public float spawnDistance = 10f;

    private float timer;
    private float spawnRate;

    void Start()
    {
        SetRandomSpawnRate();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnMeteor();
            SetRandomSpawnRate();
        }
    }

    void SpawnMeteor()
    {
        float randomDistance = Random.Range(-spawnDistance, spawnDistance);
        Vector3 spawnPosition = new Vector3(
            transform.position.x + randomDistance,
            transform.position.y,
            transform.position.z
        );
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }

    void SetRandomSpawnRate()
    {
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        timer = spawnRate;
    }
}