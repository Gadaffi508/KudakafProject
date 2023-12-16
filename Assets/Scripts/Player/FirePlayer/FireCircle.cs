using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircle : MonoBehaviour
{
    public float Radius;

    private void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position,Radius);
        foreach (Collider2D plCol in col)
        {
            if (plCol.TryGetComponent(out PlayerHealth health))
            {
                health.TakeDamage(10);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
}
