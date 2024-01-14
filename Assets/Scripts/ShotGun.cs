using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    
    public float speed = 5f;
    public GameObject player;
    public GameObject projectilePrefab;
    public float shootInterval = 1.0f;
    private float shootTimer;
    
    public float arcAngle = 45f;
    
    private void Start()
    {
        player = GameObject.Find("Sun");
        shootTimer = shootInterval;
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
        // Instantiate the first projectile directly in the current direction
        Instantiate(projectilePrefab, transform.position, transform.rotation);

        // Instantiate the second and third projectiles with a simple rotation
        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z + 45));
        Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, transform.eulerAngles.z - 45));
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
