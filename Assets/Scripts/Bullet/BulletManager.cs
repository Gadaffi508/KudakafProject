using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletManager : MonoBehaviour
{
    internal Rigidbody2D rb;
    internal bool forcePlayer;

    public float radius;
    public float Force;
    public LayerMask LayerHit;

    public float m_Thrust = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            StartCoroutine(PlayerSpeedZero(hitCollider));
            hitCollider.GetComponentInParent<Rigidbody2D>().AddForce(direction);
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        explode();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator PlayerSpeedZero(Collider2D col)
    {
        col.GetComponentInParent<Player>().SpeedZero = true;
        yield return new WaitForSeconds(1);
        col.GetComponentInParent<Player>().SpeedZero = false;
    }
}
