using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public Points point;
    public float force;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized*force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.CompareTag("EnemyBullet"))
        {
            if (other.gameObject.CompareTag("PlayerBullet"))
            {
                Destroy(gameObject);
            }
        }
        if (this.CompareTag("PlayerBullet"))
        {

            if (other.gameObject.CompareTag("EnemyBullet"))
            {
                Destroy(gameObject);
            }
            else
            {
                point.count++;

                point.DisplayCount();
            }
        }

    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
