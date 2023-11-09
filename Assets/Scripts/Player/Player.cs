using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [Range (0,20)]
    public float speed;
    public float jumpForce;
    
    [SerializeField] private float dashSpeed;
    [Range(0, 1)]
    [SerializeField] private float dashDuration;
    
    private Rigidbody2D rb;
    private PlayerInputController _playerInputController;
    private bool jump;
    private bool isDashing = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        if(!isDashing) rb.velocity = RigidBodyVelocityMove();

        if (_playerInputController.JumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
        
        Run();
        
        if (_playerInputController.DashPress && !isDashing) StartCoroutine(Dash());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) jump = true;
    }

    private Vector2 RigidBodyVelocityMove() => new Vector2(_playerInputController.currentMovement.x * speed,rb.velocity.y);

    public void Run()
    {
        if (_playerInputController.RunPrees) speed = 10;
        else speed = 5;
    }
    
    private IEnumerator Dash()
    {
        rb.AddForce(Vector2.right *transform.GetComponentInChildren<PlayerSpiteManager>().LocalX* dashSpeed);
        isDashing = true;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
