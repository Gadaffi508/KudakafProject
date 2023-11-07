using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private PlayerController playerInput;
    internal Vector2 currentMovement;
    internal Vector2 CursorPos;
    internal bool JumpPressed;

    internal bool RunPrees;

    private void Awake()
    {
        playerInput = new PlayerController();

        playerInput.GamePlay.Move.performed += ctx =>currentMovement = ctx.ReadValue<Vector2>();
        playerInput.GamePlay.Cursor.performed += ctx =>CursorPos = ctx.ReadValue<Vector2>();
        playerInput.GamePlay.Jump.performed += ctx => JumpPressed = ctx.ReadValueAsButton();

        playerInput.GamePlay.RunPressed.performed += ctx => RunPrees = ctx.ReadValueAsButton();
    }

    private void OnEnable()
    {
        playerInput.GamePlay.Enable();
    }

    private void OnDisable()
    {
        playerInput.GamePlay.Disable();
    }
}
