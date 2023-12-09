using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTalent : MonoBehaviour
{
    [Header("Lef Talent"),Tooltip("Hight Wall")]
    public GameObject FireWall;
    [Header("Right Talent"), Tooltip("Burning Circle")]
    public GameObject FireCircle;
    [Header("Down Talent"), Tooltip("Flying Flame")]
    public GameObject FireWind;
    [Header("Up Talent"), Tooltip("Fire Ball")]
    public GameObject FirePrefabs;
    public GameObject FireEffect;
    public Transform FirePos;

    [Header("Cool Down Panel")]
    public GameObject FirePanel;
    public GameObject[] PressKeys;

    private PlayerInputController _controller;
    private int f_index;
    private int s_index;
    private bool FireOne = true;
    private bool press = false;
    private bool SecondFire = false;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        FirePanel.SetActive(true);

        foreach (GameObject key in PressKeys)
        {
            key.SetActive(false);
        }
    }

    private void Update()
    {
        PressTalent();

        if (_controller.FirePressed && FireOne && press)
        {
            Talent();
            FireOne = false;
        }

        if (_controller.FirePressed && SecondFire && s_index <= 4)
        {
            InstFireBall();
            s_index++;
            SecondFire = false;
        }

        if (!_controller.FirePressed && !FireOne) SecondFire = true;
    }

    private void PressTalent()
    {
        if (_controller.LeftTalent) SelectTalentActive(0);

        if (_controller.RightTalent) SelectTalentActive(1);

        if (_controller.DownTalent) SelectTalentActive(2);

        if (_controller.UpTalent) SelectTalentActive(3);
    }

    private void SelectTalentActive(int index)
    {
        foreach (GameObject key in PressKeys)
        {
            key.SetActive(false);
        }

        PressKeys[index].SetActive(true);
        f_index = index;
        press = true;
        FireOne = true;

        if (index == 3)
        {
            s_index = 0;
            SecondFire = true;
        }
        else
        {
            s_index++;
            SecondFire = false;
        }
    }

    private void Talent()
    {
        switch (f_index)
        {
            case 0:
                InstFireWall();
                break;
            case 1:
                InstFireCircle();
                break;
            case 2:
                InstFireWind();
                break;
            case 3:
                InstFireBall();
                break;
            default:
                Debug.Log("Dont Press");
                break;
        }
    }

    private void InstFireWall()
    {
        GameObject Wall = Instantiate(FireWall, FireArea(), transform.rotation);
        Destroy(Wall,1f);
    }

    private void InstFireCircle()
    {
        GameObject Circle = Instantiate(FireCircle, transform.position, transform.rotation, transform);
        Destroy(Circle, 1f);
    }

    private void InstFireWind()
    {
        GameObject Wind = Instantiate(FireWind, transform.position, transform.rotation);
        Wind.GetComponent<Transform>().localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        Wind.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x,0) * Time.deltaTime * 400000);
        Destroy(Wind, 1f);
    }

    private void InstFireBall()
    {
        GameObject bullet = InstateFireProperty(FirePrefabs);
        GameObject fireEffect = InstateFireProperty(FireEffect);
        Destroy(fireEffect, .5f);
    }

    private Vector2 FireArea()
    {
        Vector2 Ppos = transform.position;
        Vector2 Fpos = FireWall.transform.position;
        Vector2 FireArea = new Vector2(Ppos.x, Fpos.y);
        return FireArea;
    }

    private GameObject InstateFireProperty(GameObject InsObj) => Instantiate(InsObj, FirePos.position, FirePos.rotation);
}
