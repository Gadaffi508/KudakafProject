using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody2D rb;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
