using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEBomb : BulletManager
{
    public override void TriggerFnc(Collision2D collision)
    {
        m_Thrust = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(Damage);
        }
    }
}
