using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpForce : BulletManager
{
    public override void StartFnc()
    {
        Destroy(gameObject,5f);
    }

    public override void TriggerFnc(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        //m_Thrust = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }

    public override void TriggerFnc(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        //m_Thrust = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
