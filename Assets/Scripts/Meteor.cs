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
        direction = (player.transform.position - transform.position).normalized;
        if (!player) Destroy(gameObject);
        Destroy(gameObject, 10f); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}