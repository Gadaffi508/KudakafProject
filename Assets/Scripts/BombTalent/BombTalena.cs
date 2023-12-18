using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTalena : BulletManager
{
    public bool isHighBomb = false;

    public override void StartFnc()
    {
        if (isHighBomb == true)
        {
            StartCoroutine(Timer());
        }
    }

    public override void TriggerFnc(Collision2D collision)
    {
        m_Thrust = 0;
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            forcePlayer = true;
            rb.velocity = Vector2.zero;
        }

        if (collision.collider.gameObject.CompareTag("Ground"))
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
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}
