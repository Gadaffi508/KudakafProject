using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSBomb : BulletManager
{
    public override void TriggerFnc(Collision2D collision)
    {
        m_Thrust = 0;
    }
}
