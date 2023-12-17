using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletManager : MonoBehaviour
{
    internal Rigidbody2D rb;
    internal bool forcePlayer;

    public int Damage;

    public float radius;
    public float Force;
    public LayerMask LayerHit;

    public float m_Thrust = 20f;

    public int PlayerIndex;
    internal int DamagePlayer;

    private bool damageded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (PlayerIndex == 1)
        {
            DamagePlayer = 0;
        }

        if (PlayerIndex == 0)
        {
            DamagePlayer = 1;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right* m_Thrust);

        if (forcePlayer)
        {
            StartCoroutine(Timer());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerFnc(collision);
    }

    public abstract void TriggerFnc(Collision2D collision);

    public void Scale()
    {
        Vector2 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void explode()
    {
        Collider2D[] rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, LayerHit);

        foreach (Collider2D hitCollider in rayInfo)
        {
            Vector2 direction = hitCollider.transform.position - transform.position;

            direction *= Force;

            hitCollider.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0,0);
            hitCollider.GetComponentInParent<Rigidbody2D>().AddForce(direction);

            if (hitCollider.gameObject.GetComponentInParent<Player>().PlayerIndex == DamagePlayer && damageded == false)
            {
                hitCollider.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
                damageded = true;
            }

            if (hitCollider == null)
            {
                damageded = false;
            }
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        explode();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
