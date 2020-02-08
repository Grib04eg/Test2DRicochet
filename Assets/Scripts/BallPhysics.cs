using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 direction;
    private CircleCollider2D collider;

    private bool running;

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (running)
            transform.position += direction * Time.deltaTime * speed;

        RaycastHit2D[] hits = new RaycastHit2D[10];
        if (collider.Raycast(direction, hits, 0.2f) > 0)
        direction = Vector2.Reflect(direction, hits[0].normal);
    }

    public void Run(Vector3 startDirection)
    {
        direction = startDirection.normalized;
        running = true;
    }
}
