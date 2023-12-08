using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletManager : MonoBehaviour
{
    internal Rigidbody2D rb;
    public float m_Thrust = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,5f);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.right* m_Thrust);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerFnc(collision);
    }

    public abstract void TriggerFnc(Collision2D collision);
}
