using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasicBomb : BulletManager
{
    public override void TriggerFnc(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Thrust = 0;
            Debug.Log("Touch");
        }
    }
}