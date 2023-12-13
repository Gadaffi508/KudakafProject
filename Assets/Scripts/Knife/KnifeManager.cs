using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    public bool isFirstPerson = true;

    private Transform knifePos;
    Animator anim;

    private void Start()
    {
        knifePos = transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Attack())
        {
            AnimTrue();
        }
    }

    public void AnimFalse() => anim.SetBool("K_Attack", false);
    public void AnimTrue() => anim.SetBool("K_Attack", true);

    private bool Attack() => isFirstPerson && PlayerInputController._Controller.FirePressed || !isFirstPerson && SPlayerInput._SController.SFirePressed;
}
