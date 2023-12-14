using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bananaman : MonoBehaviour
{
    [Header("Fire AllPos")]
    public Transform FirePos;

    [Header("Lef Talent"), Tooltip("Only Banana Bomb")]
    public GameObject Only_Banana;
    [Header("Right Talent"), Tooltip("A Lot of Only_Banana")]
    public GameObject Bananas;
    [Header("Down Talent"), Tooltip("Speed and Jump Enhancer")]
    public float Power_Enhancer_speed, Power_Enhancer_jump;
    public int jumpLenghtTime;
    [Header("Up Talent"), Tooltip("collecting and throwing banana mines")]
    public List<GameObject> CollectBananaMine = new List<GameObject>();
    public List<GameObject> UpTalentImage = new List<GameObject>();
    public int MineLenght = 0;

    [Header("Cool Down Panel")]
    public GameObject Bananapanel;
    public GameObject[] PressKeys;
    public float LCoolDownTime, RCoolDownTime, DCoolDownTime, UCoolDownTime;

    private PlayerInputController _controller;
    private Player _player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

    private bool UpTalentStart = false;
    private bool UptalentPress = false;
    private int MineCLenght = 0;

    private bool lefttalent = true,
    righttalent = true,
    downtalent = true,
    uptalen = true;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        _player = GetComponentInParent<Player>();
        Bananapanel.SetActive(true);

        ForeachObjsActive(PressKeys);
    }

    private void Update()
    {
        PressTalent();

        if (_controller != null && _controller.FirePressed && FireOne && press)
        {
            Talent();
            FireOne = false;
        }

        if (_controller != null && _controller.FirePressed && UpTalentStart && MineCLenght > 0 && UptalentPress == false)
        {
            CollectStart();
            UptalentPress = true;
        }

        if (_controller != null && _controller.FirePressed == false) UptalentPress = false;

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
                Collection();
                StartCoroutine(UCoolDown());
                break;
        }
    }

    private void PressTalent()
    {
        if (_controller != null && _controller.LeftTalent && lefttalent) ActiveTalent(0);

        if (_controller != null && _controller.RightTalent && righttalent) ActiveTalent(1);

        if (_controller != null && _controller.DownTalent && downtalent) ActiveTalent(2);

        if (_controller != null && _controller.UpTalent && uptalen) ActiveTalent(3);
    }

    private void InsBananaBullet(GameObject B_bullet, Transform T_bullet)
    {
        Instantiate(B_bullet, T_bullet.position, T_bullet.rotation);
    }

    private void Collection()
    {
        MineLenght = CollectBananaMine.Count;
        if (MineLenght > 7) MineCLenght = 7;
        else MineCLenght = MineLenght;

        while (MineCLenght > 0)
        {
            MineCLenght--;
            UpTalentImage[MineCLenght].SetActive(true);
        }

        foreach (GameObject Mine in CollectBananaMine)
        {
            Mine.GetComponent<Mine>().Collection();
        }
        CollectBananaMine.Clear();

        StartCoroutine(DelayUpTalentS());
    }

    IEnumerator DelayUpTalentS()
    {
        yield return new WaitForSeconds(0.5f);
        UpTalentStart = true;

        MineCLenght = MineLenght;
    }

    private void CollectStart()
    {
        InsBananaBullet(Only_Banana, FirePos);
        MineCLenght--;
        if (MineCLenght < 8) UpTalentImage[MineCLenght].SetActive(false);
    }

    private void ActiveTalent(int index)
    {
        ForeachObjsActive(PressKeys);

        PressKeys[index].SetActive(true);
        f_index = index;
        FireOne = true;
        press = true;

        if (f_index == 3)
        {
            MineLenght = 0;
        }
        else
        {
            UpTalentStart = false;
            ForeachObjsActive(UpTalentImage);

        }
    }

    IEnumerator LCoolDown()
    {
        lefttalent = false;
        yield return new WaitForSeconds(LCoolDownTime);
        lefttalent = true;
        FireOne = false;
    }

    IEnumerator RCoolDown()
    {
        righttalent = false;
        yield return new WaitForSeconds(RCoolDownTime);
        righttalent = true;
        FireOne = false;
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
        FireOne = false;
    }

    IEnumerator UCoolDown()
    {
        uptalen = false;
        yield return new WaitForSeconds(UCoolDownTime);
        uptalen = true;
        FireOne = false;
    }

    public void ForeachObjsActive(GameObject[] OBjs)
    {
        foreach (GameObject key in OBjs)
        {
            key.SetActive(false);
        }
    }

    public void ForeachObjsActive(List<GameObject> OBjs)
    {
        foreach (GameObject key in OBjs)
        {
            key.SetActive(false);
        }
    }
}
