using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    public float speed = 10;
    public float direction;
    public float maxSpeed = 25;

    private Rigidbody2D rb;
    private Transform player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null) 
        {
            Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
