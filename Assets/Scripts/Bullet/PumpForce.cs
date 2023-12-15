using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpForce : BulletManager
{
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
        }

        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(Damage);
        }
    }
}
