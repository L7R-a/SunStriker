using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Character body
    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector3 direction;


    void Start()
    {
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
}
