using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Character body
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 direction;

    //Projectile Spawn
    public Projectile projectilePrefab;
    public Transform launch;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();
        //Launch Projectile
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, launch.position, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
