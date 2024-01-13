using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4.5f;
    void Start()
    {

    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "PlayerProjectileIgnore")
        Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
