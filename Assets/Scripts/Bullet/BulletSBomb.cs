using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSBomb : BulletManager
{
    public override void StartFnc()
    {
        
    }

    public override void TriggerFnc(Collision2D collision)
    {
        m_Thrust = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.velocity = Vector2.zero;
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
        }
    }

    public override void TriggerFnc(Collider2D collision)
    {
        m_Thrust = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.velocity = Vector2.zero;
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}

