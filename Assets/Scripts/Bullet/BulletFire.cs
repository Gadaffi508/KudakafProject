using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : BulletManager
{
    public override void StartFnc()
    {
        Destroy(gameObject, 5f);
    }

    public override void TriggerFnc(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }

    public override void TriggerFnc(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerIndex != collision.gameObject.GetComponentInParent<Player>().PlayerIndex)
            {
                collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
