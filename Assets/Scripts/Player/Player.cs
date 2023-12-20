using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public string PlayerGamePadName;

    [Range(0, 20)]
    public float speed;
    public float R_speed;
    public float L_speed;
    public float jumpForce;

    public bool bananaTalent = false;
    public int jumplenght = 0;

    public bool SpeedZero = false;

    public int PlayerIndex = 0;
    public GameObject text;

    [SerializeField] private float dashSpeed;
    [Range(0, 1)]
    [SerializeField] private float dashDuration;

    private Rigidbody2D rb;
    private bool jump;
    private bool isDashing = false;

    private float SpeedZerotime;

    private PlayerInputHandler handler;

    internal bool İsFly = false;

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
    internal bool PunchPress;
    internal bool ExplodePress;

    private void Start()
    {
        handler = FindObjectOfType<PlayerInputHandler>();
        handler.player.Add(this);

        rb = GetComponent<Rigidbody2D>();


        

    }

    private void Update()
    {
        text.GetComponent<TextMeshPro>().text = $"P{PlayerIndex+ 1}";
        if (!isDashing && !İsFly && SpeedZero == false) rb.velocity = RigidBodyVelocityMove();
        if (!isDashing && İsFly && SpeedZero == false) rb.velocity = RigidBodyVelocityFly();

        if (JumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;

            jumplenght++;
        }

        Run();

        if (JumpPressed == false && bananaTalent == true)
        {
            jump = true;
        }

        if (DashPress && !isDashing) StartCoroutine(Dash());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) jump = true;
    }

    private Vector2 RigidBodyVelocityMove() => new Vector2(currentMovement.x * speed, rb.velocity.y);
    private Vector2 RigidBodyVelocityFly() => new Vector2(currentMovement.x * speed, currentMovement.y * speed);

    public void Run()
    {
        if (RunPrees) speed = R_speed;
        else speed = L_speed;
    }

    public IEnumerator Dash()
    {
        rb.AddForce(Vector2.right * transform.GetComponentInChildren<PlayerSpiteManager>().LocalX * dashSpeed);
        isDashing = true;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }

    public void OnMove(InputAction.CallbackContext ctx) => currentMovement = ctx.ReadValue<Vector2>();
    public void OnCursor(InputAction.CallbackContext ctx) => CursorPos = ctx.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext ctx) => RunPrees = ctx.ReadValueAsButton();
    public void OnDash(InputAction.CallbackContext ctx) => DashPress = ctx.ReadValueAsButton();
    public void OnRun(InputAction.CallbackContext ctx) => JumpPressed = ctx.ReadValueAsButton();
    public void OnFire(InputAction.CallbackContext ctx) => FirePressed = ctx.ReadValueAsButton();
    public void OnLeft(InputAction.CallbackContext ctx) => LeftTalent = ctx.ReadValueAsButton();
    public void OnRight(InputAction.CallbackContext ctx) => RightTalent = ctx.ReadValueAsButton();
    public void OnUp(InputAction.CallbackContext ctx) => UpTalent = ctx.ReadValueAsButton();
    public void OnDown(InputAction.CallbackContext ctx) => DownTalent = ctx.ReadValueAsButton();
    public void OnPunch(InputAction.CallbackContext ctx) => PunchPress = ctx.ReadValueAsButton();
    public void OnExplode(InputAction.CallbackContext ctx) => ExplodePress = ctx.ReadValueAsButton();
}
