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
    internal bool FirePressed;
    internal bool DashPress;

    internal bool RunPrees;
    internal bool LeftTalent;
    internal bool RightTalent;
    internal bool UpTalent;
    internal bool DownTalent;

    public static PlayerInputController _Controller;
    public static PlayerInputController Controller
    {
        get
        {
            if (_Controller is null)
                Debug.LogError("Controller is null");
            return _Controller;
        }
    }

    private void Awake()
    {
        _Controller = this;
        
        playerInput = new PlayerController();

        playerInput.GamePlay.Move.performed += ctx =>currentMovement = ctx.ReadValue<Vector2>();
        playerInput.GamePlay.Cursor.performed += ctx =>CursorPos = ctx.ReadValue<Vector2>();
        playerInput.GamePlay.Jump.performed += ctx => JumpPressed = ctx.ReadValueAsButton();
        playerInput.GamePlay.DashPressed.performed += ctx => DashPress = ctx.ReadValueAsButton();

        playerInput.GamePlay.RunPressed.performed += ctx => RunPrees = ctx.ReadValueAsButton();
        
        playerInput.GamePlay.FirePressed.performed += ctx => FirePressed = ctx.ReadValueAsButton();

        playerInput.GamePlay.TalentOne.performed += ctx => LeftTalent = ctx.ReadValueAsButton();
        playerInput.GamePlay.TalentSecond.performed += ctx => RightTalent = ctx.ReadValueAsButton();
        playerInput.GamePlay.TalentThird.performed += ctx => UpTalent = ctx.ReadValueAsButton();
        playerInput.GamePlay.TalentFourth.performed += ctx => DownTalent = ctx.ReadValueAsButton();
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
