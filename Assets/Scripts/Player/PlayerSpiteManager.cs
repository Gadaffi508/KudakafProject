using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpiteManager : MonoBehaviour
{
    public Transform PunchPos;

    public float radius;
    public float Force;
    public LayerMask LayerHit;

    internal int LocalX = 1;
    public bool FireC;
    public int Direct = 1;

    private Animator anim;
    private Rigidbody2D rb;
    Player player;

    RaycastHit2D hit;

    public bool isBlackPlayer = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FireC)
        {
            anim.SetFloat("Horizontal", rb.velocity.x);
            anim.SetFloat("Vertical", rb.velocity.y);
        }

        anim.SetFloat("speed", Math.Abs(rb.velocity.x + rb.velocity.y));
        Flip();

        if (isBlackPlayer == true)
        {
            hit = Physics2D.Linecast(PunchPos.position, Vector2.right * 10);

            if (hit.collider != null)
            {
                if (hit.collider.name == "Player" && player.PunchPress)
                {
                    Explode();
                }
            }
        }
    }

    private void Flip()
    {
        if (rb.velocity.x > 0) LocalX = 1;

        if (rb.velocity.x < 0) LocalX = -1;

        transform.localScale = FlipVector(LocalX);
    }
    private Vector3 FlipVector(int x) => new Vector3(x * Direct, 1, 1);

    public void Explode()
    {
        Collider2D[] rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, LayerHit);

        foreach (Collider2D hitCollider in rayInfo)
        {
            Vector2 direction = hitCollider.transform.position - transform.position;

            direction *= Force;

            hitCollider.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hitCollider.GetComponentInParent<Rigidbody2D>().AddForce(direction);
        }
    }
}
