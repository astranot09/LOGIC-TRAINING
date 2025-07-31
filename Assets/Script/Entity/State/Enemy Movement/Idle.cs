using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public float speed = 0;
    public float maxSpeed = 25;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0 * speed, rb.velocity.y);
        transform.localScale = new Vector3(1f, 2.6122f, 1f);
        Debug.Log("Idle");
    }
}
