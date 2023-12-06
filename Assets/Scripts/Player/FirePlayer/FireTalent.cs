using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTalent : MonoBehaviour
{
    public GameObject FireWall;
    public GameObject FireCircle;
    public GameObject FireWind;

    private PlayerInputController _controller;

    private bool FireWB = true;
    private bool FireC = true;
    private bool FireW = true;
    private GameObject FireWObj;
    private GameObject FireCObj;
    private GameObject FireCWiObj;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerInputController>();
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

        if(_controller.FirePressed)
        {
            FireCWiObj?.GetComponent<Animator>().SetTrigger("FireW");
            FireCWiObj?.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Time.deltaTime * 400000);
            Destroy(FireCWiObj, 1f);
            FireCWiObj = null;
        }
    }

    private void PressTalent()
    {
        if (_controller.LeftTalent) InstFireWall();

        if (_controller.RightTalent) InstFireCircle();

        if (_controller.DownTalent) InstFireWind();
    }
    private void InstFireWall()
    {
        if (FireWB)
        {
            FireWObj = Instantiate(FireWall, FireArea(), transform.rotation);

            FireWB = false;
        }
    }

    private void InstFireCircle()
    {
        if (FireC)
        {
            FireCObj = Instantiate(FireCircle, transform.position, transform.rotation, transform);

            FireC = false;
        }
    }

    private void InstFireWind()
    {
        if (FireW)
        {
            FireCWiObj = Instantiate(FireWind, transform.position, transform.rotation);
            FireCWiObj.GetComponent<Transform>().localScale = transform.localScale;

            FireW = false;
        }
    }

    private Vector2 FireArea()
    {
        Vector2 Ppos = transform.position;
        Vector2 Fpos = FireWall.transform.position;
        Vector2 FireArea = new Vector2(Ppos.x, Fpos.y);
        return FireArea;
    }
}
