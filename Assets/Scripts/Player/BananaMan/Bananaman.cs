using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bananaman : MonoBehaviour
{
    [Header("Fire AllPos")]
    public Transform[] FirePos;

    [Header("Lef Talent"), Tooltip("Only Banana Bomb")]
    public GameObject[] Only_Banana;
    [Header("Right Talent"), Tooltip("A Lot of Only_Banana")]
    public GameObject[] Bananas;
    [Header("Down Talent"), Tooltip("Speed and Jump Enhancer")]
    public float Power_Enhancer_speed, Power_Enhancer_jump;
    public int jumpLenghtTime;
    [Header("Up Talent"), Tooltip("collecting and throwing banana mines")]
    public List<GameObject> CollectBananaMine = new List<GameObject>();

    [Header("Cool Down Panel")]
    public GameObject Bananapanel;
    public GameObject[] PressKeys;
    public float LCoolDownTime, RCoolDownTime, DCoolDownTime,UCoolDownTime;

    private PlayerInputController _controller;
    private Player _player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

    private bool lefttalent = true,
    righttalent = true,
    downtalent = true,
    uptalen = true;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        _player = GetComponentInParent<Player>();
        Bananapanel.SetActive(true);

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

        if (_player.jumplenght > jumpLenghtTime)
        {
            _player.jumplenght = 0;
            _player.bananaTalent = false;
        }
    }

    private void Talent()
    {
        switch (f_index)
        {
            case 0:
                InsBananaBullet(Only_Banana, FirePos);
                StartCoroutine(LCoolDown());
                break;
            case 1:
                InsBananaBullet(Bananas, FirePos);
                StartCoroutine(RCoolDown());
                break;
            case 2:
                StartCoroutine(DCoolDown());
                break;
            case 3:
                StartCoroutine(UCoolDown());
                break;
        }
    }

    private void PressTalent()
    {
        if (_controller.LeftTalent && lefttalent) ActiveTalent(0);

        if (_controller.RightTalent && righttalent) ActiveTalent(1);

        if (_controller.DownTalent && downtalent) ActiveTalent(2);

        if (_controller.UpTalent && uptalen) ActiveTalent(3);
    }

    private void InsBananaBullet(GameObject[] B_bullet, Transform[] T_bullet)
    {
        for (int i = 0; i < B_bullet.Length; i++)
        {
            Instantiate(B_bullet[i], T_bullet[i].position, T_bullet[i].rotation);
        }
    }

    private void ActiveTalent(int index)
    {
        foreach (GameObject key in PressKeys)
        {
            key.SetActive(false);
        }

        PressKeys[index].SetActive(true);
        f_index = index;
        FireOne = true;
        press = true;
    }

    IEnumerator LCoolDown()
    {
        lefttalent = false;
        yield return new WaitForSeconds(LCoolDownTime);
        lefttalent = true;
    }

    IEnumerator RCoolDown()
    {
        righttalent = false;
        yield return new WaitForSeconds(RCoolDownTime);
        righttalent = true;
    }

    IEnumerator DCoolDown()
    {
        _player.jumplenght = 0;
        downtalent = false;
        _player.L_speed += Power_Enhancer_speed;
        _player.bananaTalent = true;

        yield return new WaitForSeconds(DCoolDownTime);
        _player.L_speed -= Power_Enhancer_speed;

        _player.jumplenght = 0;
        _player.bananaTalent = false;

        downtalent = true;
    }

    IEnumerator UCoolDown()
    {
        uptalen = false;
        yield return new WaitForSeconds(UCoolDownTime);
        uptalen = true;
    }
}
