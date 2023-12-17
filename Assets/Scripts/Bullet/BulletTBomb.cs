using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTBomb : BulletManager
{
    public override void TriggerFnc(Collision2D collision)
    {
        m_Thrust = 0;
        if (collision.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
        }
    }


}
