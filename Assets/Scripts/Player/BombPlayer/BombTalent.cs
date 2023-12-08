using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class BombTalent : MonoBehaviour
{
    [Header("Fire AllPos")]
    public Transform FirePos;

    [Header("Lef Talent"), Tooltip("Basic Bomb")]
    public GameObject B_Bomb;
    [Header("Right Talent"), Tooltip("Clinging Bomb")]
    public GameObject C_Bomb;
    [Header("Down Talent"), Tooltip("High Bomb")]
    public GameObject H_Bomb;

    [Header("Up Talent"), Tooltip("Change Charecter")]
    public GameObject BombCharecter;

    [Header("Cool Down Panel")]
    public GameObject BombPanel;
    public GameObject[] PressKeys;

    private PlayerInputController _controller;
    private int f_index;
    private int S_index = 1;
    private bool FireOne = true;
    private bool press = false;
    private bool SecondFire = false;

    private void Awake()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        BombPanel.SetActive(true);

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
            S_index++;
            SecondFire = false;
        }

        if (_controller.FirePressed && SecondFire && S_index == 1)
        {
            InstBomb(C_Bomb);
            S_index++;
            SecondFire = false;
        }

        if (!_controller.FirePressed && !FireOne) SecondFire = true;
    }

    private void Talent()
    {
        switch (f_index)
        {
            case 0:
                InstBomb(B_Bomb);
                break;
            case 1:
                InstBomb(C_Bomb);
                break;
            case 2:
                InstBomb(H_Bomb);
                break;
            case 3:
                ChangeCharecter();
                break;
        }
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

        if (index == 1)
        {
            S_index = 0;
            SecondFire = true;
        }
        else
        {
            S_index++;
            SecondFire = false;
        }
    }

    private void InstBomb(GameObject bomb)
    {
        Instantiate(bomb, FirePos.position, transform.rotation);
    }

    private void ChangeCharecter()
    {
        this.gameObject.SetActive(false);
        BombCharecter.SetActive(true);
    }
}
