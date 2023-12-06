using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPlayer : MonoBehaviour
{
    [Range (0,20)]
    public float speed;
    public float jumpForce;
    
    [SerializeField] private float dashSpeed;
    [Range(0, 1)]
    [SerializeField] private float dashDuration;
    
    private Rigidbody2D rb;
    private SPlayerInput _splayerInputController;
    private bool jump;
    private bool isDashing = false;

    internal bool İsFly;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _splayerInputController = GetComponent<SPlayerInput>();
    }

    private void Update()
    {
        if(!isDashing && !İsFly) rb.velocity = RigidBodyVelocityMove();
        if(!isDashing && İsFly) rb.velocity = RigidBodyVelocityFly();

        if (_splayerInputController.SJumpPressed && jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
        
        Run();
        
        //if (_splayerInputController.DashPress && !isDashing) StartCoroutine(Dash());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) jump = true;
    }

    private Vector2 RigidBodyVelocityMove() => new Vector2(_splayerInputController.scurrentMovement.x * speed,rb.velocity.y);
    private Vector2 RigidBodyVelocityFly() => new Vector2(_splayerInputController.scurrentMovement.x * speed,_splayerInputController.scurrentMovement.y * speed);

    public void Run()
    {
        /*if (_splayerInputController.RunPrees) speed = 10;
        else speed = 5;*/
    }
    
    private IEnumerator Dash()
    {
        rb.AddForce(Vector2.right *transform.GetComponentInChildren<PlayerSpiteManager>().LocalX* dashSpeed);
        isDashing = true;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
}
