using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [Range (0,20)]
    public float speed;
    public float jumpForce;

    public GameObject CursorObj;
    public float CursorSpeed;
    
    private Rigidbody2D rb;
    private PlayerInputController _playerInputController;
    private Animator anim;
    private bool jump;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerInputController = GetComponent<PlayerInputController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(_playerInputController.currentMovement.x * speed,rb.velocity.y);

        if (_playerInputController.JumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
        
        anim.SetFloat("speed",Math.Abs(rb.velocity.x));
        
        CursorObj.transform.Translate(CursorMovement());

        Flip();
        Run();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

    private Vector3 CursorMovement() => _playerInputController.CursorPos * Time.deltaTime * CursorSpeed;

    private Vector3 FlipVector(int x) => new Vector3(x,1,1);

    private void Flip()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = FlipVector(1);
        }

        if (rb.velocity.x < 0)
        {
            transform.localScale = FlipVector(-1);
        }
    }

    public void Run()
    {
        if (_playerInputController.RunPrees)
        {
            speed = 10;
        }
        else speed = 5;
    }
}
