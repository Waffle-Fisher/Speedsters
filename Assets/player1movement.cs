using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 10f;
    public float fastFallSpeed = 6f;
    private bool isJumping = false;
    private bool isFastFalling = false;
    private int jumps = 2;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float moveInput = Input.GetAxis("Horizontal1");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }



        if (Input.GetKeyDown(KeyCode.W) && (!isJumping || jumps > 0))
        {
            rb.AddForce(Vector2.up * (jumpForce - 1), ForceMode2D.Impulse);
            isJumping = true;
            jumps--;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, -fastFallSpeed);
                isFastFalling = true;
            }
        }
        else
        {
            isFastFalling = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isFastFalling = false;
            jumps = 2;
        }
    }
}