using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTBomb : BulletManager
{
    public override void TriggerFnc(Collision2D collision)
    {
        m_Thrust = 0;
    }
}
