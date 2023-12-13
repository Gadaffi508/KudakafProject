using System;
using System.Collections;
using UnityEngine;

public class Player: MonoBehaviour
{
    [Range (0,20)]
    public float speed;
    public float R_speed;
    public float L_speed;
    public float jumpForce;

    public bool bananaTalent = false;
    public int jumplenght = 0;

    [SerializeField] private float dashSpeed;
    [Range(0, 1)]
    [SerializeField] private float dashDuration;
    
    private Rigidbody2D rb;
    private PlayerInputController _playerInputController;
    private bool jump;
    private bool isDashing = false;

    internal bool İsFly;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerInputController = GetComponent<PlayerInputController>();
    }

    private void Update()
    {
        if(!isDashing && !İsFly) rb.velocity = RigidBodyVelocityMove();
        if(!isDashing && İsFly) rb.velocity = RigidBodyVelocityFly();

        if (_playerInputController.JumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;

            jumplenght++;
        }
        
        Run();

        if (_playerInputController.JumpPressed == false && bananaTalent == true)
        {
            jump = true;
        }
        
        if (_playerInputController.DashPress && !isDashing) StartCoroutine(Dash());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) jump = true;
    }

    private Vector2 RigidBodyVelocityMove() => new Vector2(_playerInputController.currentMovement.x * speed,rb.velocity.y);
    private Vector2 RigidBodyVelocityFly() => new Vector2(_playerInputController.currentMovement.x * speed,_playerInputController.currentMovement.y * speed);

    public void Run()
    {
        if (_playerInputController.RunPrees) speed = R_speed;
        else speed = L_speed;
    }
    
    public IEnumerator Dash()
    {
        rb.AddForce(Vector2.right *transform.GetComponentInChildren<PlayerSpiteManager>().LocalX* dashSpeed);
        isDashing = true;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
