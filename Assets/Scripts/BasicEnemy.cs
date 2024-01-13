using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed = 5f;
    private int direction = 1;
    public GameObject player;

    public GameObject projectilePrefab;
    public float shootInterval = 1.0f;
    private float shootTimer;

    private void Start()
    {
        shootTimer = shootInterval;
        player = GameObject.Find("Sun"); // Find the game object named "Sun" and set it as the player
    }

    private void Update()
    {
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        Vector2 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.x > 1 || screenPosition.x < 0)
        {
            direction *= -1;
        }

        Vector2 directionToPlayer = player.transform.position - transform.position;
        transform.up = directionToPlayer;

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            ShootProjectile();
            shootTimer = shootInterval;
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}