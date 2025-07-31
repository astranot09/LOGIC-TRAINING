using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveInput;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (moveInput.sqrMagnitude > 0)
        {
            lastMoveInput = moveInput;

            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", moveInput.x);
            animator.SetFloat("InputY", moveInput.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("InputX", 0f);
            animator.SetFloat("InputY", 0f);

            animator.SetFloat("LastInputX", lastMoveInput.x);
            animator.SetFloat("LastInputY", lastMoveInput.y);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}
