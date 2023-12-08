using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFire : BulletManager
{
    public override void TriggerFnc(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
