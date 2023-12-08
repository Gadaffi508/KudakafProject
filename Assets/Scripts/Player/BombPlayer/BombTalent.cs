using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class BombTalent : MonoBehaviour
{
    [Header("Cool Down Panel")]
    public GameObject BombPanel;
    public GameObject[] PressKeys;

    private PlayerInputController _controller;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

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
            //Talent();
            FireOne = false;
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
    }
}
