using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageGround : MonoBehaviour
{
    public int Damage;
    private float DamageTime = 0;
    public int playerIndex;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DamageTime += Time.deltaTime;

            if (DamageTime > 1)
            {
                collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
                DamageTime = 0;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        DamageTime += Time.deltaTime;

        if (DamageTime > 1 && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
            DamageTime = 0;
        }
    }
}
