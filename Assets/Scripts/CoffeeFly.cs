using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeFly : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject mugHitSound;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CoffeeStop")
        {
            Instantiate(mugHitSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.tag == "CoffeeTarget")
        {
            Destroy(gameObject);
        }
    }
}
