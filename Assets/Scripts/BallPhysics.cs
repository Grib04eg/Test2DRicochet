using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 direction;
    private Rigidbody2D rb;

    private bool running;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (running)
            rb.MovePosition(rb.position + direction * Time.deltaTime * speed);
    }

    public void Run(Vector3 startDirection)
    {
        direction = startDirection.normalized;
        running = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        if (collision.contactCount > 1)
        {
            for (int i = 1; i < collision.contactCount; i++)
            {
                if (collision.contacts[i].normal != collision.contacts[0].normal)
                    direction = Vector2.Reflect(direction, collision.contacts[i].normal);
            }
        }
    }
}
