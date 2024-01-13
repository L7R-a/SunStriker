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
        Destroy(gameObject, 10f); 
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}