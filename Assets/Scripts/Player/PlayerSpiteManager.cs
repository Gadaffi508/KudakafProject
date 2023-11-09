using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpiteManager : MonoBehaviour
{
    internal int LocalX = 1;
    
    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed",Math.Abs(rb.velocity.x));
        Flip();
    }
    
    private void Flip()
    {
        if (rb.velocity.x > 0) LocalX = 1;

        if (rb.velocity.x < 0) LocalX = -1;
        
        transform.localScale = FlipVector(LocalX);
    }
    private Vector3 FlipVector(int x) => new Vector3(x,1,1);
}