using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    public GameObject projectilePrefab;
    public float shootInterval = 1.0f;
    private float shootTimer;

    private void Start()
    {
        shootTimer = shootInterval;
        player = GameObject.Find("Sun");
        if (!player) Destroy(gameObject);
        

    }

    private void Update()
    {
        if (!player) Destroy(gameObject);

        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Rotate towards the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

            // Move towards the player
            transform.position += direction * speed * Time.deltaTime;

            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                ShootProjectile();
                shootTimer = shootInterval;
            }
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