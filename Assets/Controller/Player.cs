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
    private PlayerController playerInput;

    private Vector2 currentMovement;
    private Vector2 CursorPos;
    private bool JumpPressed;
    private bool jump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


        playerInput = new PlayerController();

        playerInput.GamePlay.Move.performed += ctx =>currentMovement = ctx.ReadValue<Vector2>();
        playerInput.GamePlay.Cursor.performed += ctx =>CursorPos = ctx.ReadValue<Vector2>();
        playerInput.GamePlay.Jump.performed += ctx => JumpPressed = ctx.ReadValueAsButton();
    }

    private void Update()
    {
        rb.velocity = new Vector2(currentMovement.x * speed,rb.velocity.y);

        if (JumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        CursorObj.transform.Translate(CursorMovement());
    }

    private void OnEnable()
    {
        playerInput.GamePlay.Enable();
    }

    private void OnDisable()
    {
        playerInput.GamePlay.Disable();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = true;
        }
    }

    private Vector3 CursorMovement() => CursorPos * Time.deltaTime * CursorSpeed;
}
