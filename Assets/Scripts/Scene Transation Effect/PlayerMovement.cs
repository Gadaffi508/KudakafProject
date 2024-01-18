using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float jumpForce;
    public Transform PLayerSprite;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = true;
    private float X;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        X = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
            isGrounded = false;
        }
        anim.SetFloat("speed",Math.Abs( rb.velocity.x));

        if (X > 0)
        {
            transform.localScale = new Vector2(-1,1);
            PLayerSprite.transform.Rotate(0,0,100 * Time.deltaTime);
        }

        if (X < 0)
        {
            transform.localScale = new Vector2(1,1);
            PLayerSprite.transform.Rotate(0,0,-100 * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(X * MoveSpeed, rb.velocity.y);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
