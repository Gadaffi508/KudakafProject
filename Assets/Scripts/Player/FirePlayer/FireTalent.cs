using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTalent : MonoBehaviour
{
    public GameObject FireWall;
    public GameObject FireCircle;

    private PlayerInputController _controller;
    private WeaponController _weaponController;

    private bool FireWB = true;
    private bool FireC = true;
    private GameObject FireWObj;
    private GameObject FireCObj;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        _weaponController = GetComponentInParent<WeaponController>();
    }

    private void Update()
    {
        PressTalent();

        if (_controller.FirePressed)
        {
            FireWObj?.GetComponent<Animator>().SetTrigger("FireW");
            Destroy(FireWObj, 2f);
            FireWObj = null;
        }

        if (_controller.FirePressed)
        {
            FireCObj?.GetComponent<Animator>().SetTrigger("FireC");
            Destroy(FireCObj, 2f);
            FireCObj = null;
        }
    }

    private void InstFireWall()
    {
        if(FireWB)
        {
            FireWObj = Instantiate(FireWall, transform.position, transform.rotation);
            
            FireWB = false;
        }
    }

    private void PressTalent()
    {
        if(_controller.LeftTalent) InstFireWall();

        if (_controller.RightTalent) InstFireCircle();

        //if(_controller.UpTalent)

        //if(_controller.DownTalent)
    }

    private void InstFireCircle()
    {
        if (FireC)
        {
            FireCObj = Instantiate(FireCircle, transform.position, transform.rotation,transform);

            FireC = false;
        }
    }
}
