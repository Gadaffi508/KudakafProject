using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasicBomb : BulletManager
{
    public override void StartFnc()
    {
        
    }

    public override void TriggerFnc(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Thrust = 0;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
        }
    }

    public override void TriggerFnc(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Thrust = 0;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
