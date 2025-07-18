using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float maxSpeed;
    private float direction;

    [Header("Jump")]
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;

    [Header("Jump Count")]
    public float maxJump = 2;
    public float JumpCount = 0;

    [Header("Dash")]
    public float dashForce = 20f;
    public float dashDuration = 0.3f;
    private bool isDashing = false;
    private float normalGravity;

    [Header("Dash Count")]
    public float maxDash = 2;
    public float DashCount = 0;

    //[Header("Health")]
    //public float health = 0;
    //public float maxHealth = 10;


    private Rigidbody2D rb;
    private bool isGrounded;
    private Coroutine dashRecoveryRoutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        //health = maxHealth;
    }
    private void Update()
    {
        direction = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("loncat");
            rb.AddForce(Vector2.up * jumpForce);
            JumpCount = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && JumpCount<maxJump)
        {
            Debug.Log("loncat");
            rb.AddForce(Vector2.up * jumpForce);
            JumpCount++;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && DashCount<maxDash && !isDashing)
        {
            StartCoroutine(Dash());

        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        DashCount++;

        rb.gravityScale = 0;
        rb.velocity = new Vector2(direction * dashForce, 0);
        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = normalGravity;
        isDashing = false;
        if (dashRecoveryRoutine == null)
        {
            dashRecoveryRoutine = StartCoroutine(RecoverDash());
        }
    }
    private IEnumerator RecoverDash()
    {
        while (DashCount > 0)
        {
            yield return new WaitForSeconds(3f);
            DashCount--;
        }

        dashRecoveryRoutine = null;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed)
        {
            rb.AddForce(Vector2.right * direction * speed);

        }
    }
}
