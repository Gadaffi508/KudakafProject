using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : MonoBehaviour
{
    public int Damage;
    private float DamageTime;

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
}
