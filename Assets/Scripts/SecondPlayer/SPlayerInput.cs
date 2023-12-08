using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayerInput : MonoBehaviour
{
    private SPlayerController playerInput;
    internal Vector2 scurrentMovement;
    internal Vector2 sCursorPos;
    internal bool SJumpPressed;
    internal bool SFirePressed;
    internal bool SDashPress;

    internal bool SRunPrees;
    internal bool SLeftTalent;
    internal bool SRightTalent;
    internal bool SUpTalent;
    internal bool SDownTalent;

    public static SPlayerInput _SController;
    
    public static SPlayerInput SController
    {
        get
        {
            if (_SController is null)
                Debug.LogError("Controller is null");
            return _SController;
        }
    }
    
    private void Awake()
    {
        _SController = this;
        
        playerInput = new SPlayerController();

        playerInput.SGamePlay.Move.performed += ctx =>scurrentMovement = ctx.ReadValue<Vector2>();
        playerInput.SGamePlay.Cursor.performed += ctx =>sCursorPos = ctx.ReadValue<Vector2>();
        playerInput.SGamePlay.jump.performed += ctx => SJumpPressed = ctx.ReadValueAsButton();

        playerInput.SGamePlay.DashPressed.performed += ctx => SDashPress = ctx.ReadValueAsButton();

        playerInput.SGamePlay.RunPressed.performed += ctx => SRunPrees = ctx.ReadValueAsButton();

        playerInput.SGamePlay.FirePressed.performed += ctx => SFirePressed = ctx.ReadValueAsButton();


        playerInput.SGamePlay.TalentOne.performed += ctx => SLeftTalent = ctx.ReadValueAsButton();
        playerInput.SGamePlay.Talentsecond.performed += ctx => SRightTalent = ctx.ReadValueAsButton();
        playerInput.SGamePlay.Talentthird.performed += ctx => SUpTalent = ctx.ReadValueAsButton();
        playerInput.SGamePlay.TalentFourth.performed += ctx => SDownTalent = ctx.ReadValueAsButton();
    }

    private void OnEnable()
    {
        playerInput.SGamePlay.Enable();
    }

    private void OnDisable()
    {
        playerInput.SGamePlay.Disable();
    }
}
