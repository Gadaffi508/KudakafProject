using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player: MonoBehaviour
{
    [Range (0,20)]
    public float speed;
    public float jumpForce;

    public GameObject CursorObj;
    public float CursorSpeed;
    
    private Rigidbody2D rb;
    private PlayerInputController _playerInputController;
    
    private bool jump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(_playerInputController.currentMovement.x * speed,rb.velocity.y);

        if (_playerInputController.JumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        CursorObj.transform.Translate(CursorMovement());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

    private Vector3 CursorMovement() => _playerInputController.CursorPos * Time.deltaTime * CursorSpeed;
}
