using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float timer;
    // Character body
    [SerializeField] private float speed = 3f;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Timer tim;
    private Rigidbody2D rb;
    private Vector3 direction;
    bool isShield = false;
    bool isHaste = false;
    bool isSlows = false;
    Renderer ren;


    void Start()
    {
        ren = GetComponent<Renderer>();
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
        if (isHaste)
        {
            rb.velocity = direction * speed * 5f;
            ren.material.color = Color.green;
        }
        else if (isSlows)
        {
            rb.velocity = direction * speed * 0.5f;
            ren.material.color = Color.red;
        }
        else
        {
            rb.velocity = direction * speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            if (isShield)
            {
                ren.material.color = Color.yellow;
                isShield = false;
            }
            else
            {
                Destroy(other.gameObject);
                gameObject.SetActive(false);
                canvas.enabled = true;
                tim.timeIsRunning = false;
            }

        }
    }

    public IEnumerator bigger()
    {
        ren.material.color = Color.red;
        gameObject.transform.localScale += new Vector3(4f,4f,4f);
        yield return new WaitForSeconds(5f);
        ren.material.color = Color.yellow;
        gameObject.transform.localScale -= new Vector3(4f, 4f, 4f);
    }

    public IEnumerator invisible()
    {
        ren.material.color = Color.black;
        yield return new WaitForSeconds(5f);
        ren.material.color = Color.yellow;
    }

    public void shield()
    {
        ren.material.color = Color.green;
        isShield = true;
    }

    public void die()
    {
        gameObject.SetActive(false);
        canvas.enabled = true;
        tim.timeIsRunning = false;
    }

    public IEnumerator giveHaste()
    {
        isHaste = true;
        yield return new WaitForSeconds(5f);
        isHaste = false;
    }

    public IEnumerator giveSlows()
    {
        isSlows = true;
        yield return new WaitForSeconds(5f);
        isSlows = false;
    }

    public void deleteAll()
    {
        foreach (BasicEnemy o in Object.FindObjectsOfType<BasicEnemy>())
        {
            o.gameObject.SetActive(false);
            Destroy(o);
        }
        foreach (HeatSeeker o in Object.FindObjectsOfType<HeatSeeker>())
        {
            o.gameObject.SetActive(false);
            Destroy(o);
        }
        foreach (Meteor o in Object.FindObjectsOfType<Meteor>())
        {
            o.gameObject.SetActive(false);
            Destroy(o);
        }
    }
}
