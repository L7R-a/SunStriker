using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Character body
    [SerializeField] private float speed = 3f;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Timer tim;
    private Rigidbody2D rb;
    private Vector3 direction;


    void Start()
    {
        canvas.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Character Movement
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();

    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
            canvas.enabled = true;
            tim.timeIsRunning = false;
        }
    }
}
