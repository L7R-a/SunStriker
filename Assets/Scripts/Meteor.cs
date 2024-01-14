using System;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    private Vector3 direction;

    void Awake()
    {
        player = GameObject.Find("Sun");
        if (!player) Destroy(gameObject);
        direction = (player.transform.position - transform.position).normalized;
        Destroy(gameObject, 20f); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Destroy(collision.gameObject);
        }
    }
}