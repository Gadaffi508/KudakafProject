using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBanana : BulletManager
{
    public GameObject Banana_Mine;
    public GameObject Banana_Bullet;
    public int playerIndex;

    private bool trigger = false;

    public override void TriggerFnc(Collision2D collision)
    {
        if (trigger == false)
        {
            Instantiate(Banana_Mine, transform.position, Banana_Mine.transform.rotation);
            trigger = true;
        }
    }

    public void Mine()
    {
        GameObject mine = Instantiate(Banana_Mine,transform.position, Banana_Mine.transform.rotation);
        mine.GetComponent<Mine>().playerIndex = playerIndex;
        Instantiate(Banana_Bullet, transform.position, transform.rotation);
        trigger = true;
        Destroy(this.gameObject);
    }

    public override void StartFnc()
    {
        
    }

    public override void TriggerFnc(Collider2D collision)
    {
        if (trigger == false)
        {
            Instantiate(Banana_Mine, transform.position, Banana_Mine.transform.rotation);
            trigger = true;
        }
    }
}
