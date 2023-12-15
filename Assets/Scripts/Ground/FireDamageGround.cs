using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageGround : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(Damage);
        }
    }
}
