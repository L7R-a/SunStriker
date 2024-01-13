using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSeeker : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float selfDestructTime = 5f;

    private float timer;

    private void Start()
    {
        timer = selfDestructTime;
        player = GameObject.Find("Sun");
    }

    private void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Rotate towards the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        // Move towards the player
        transform.position += direction * speed * Time.deltaTime;

        // Self-destruct timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(gameObject);
        }
    }
}