using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PumpShoot : MonoBehaviour
{
    [Header("Lef Talent"), Tooltip("Shotgun blast spread")]
    public GameObject Bullet;
    public Transform[] FirePos;

    [Header("Right Talent"), Tooltip("Heal")]
    public float HealAmount;
    public float speedAmount;
    [Header("Cool Down Panel")]
    public GameObject PumpPanel;
    public GameObject[] PressKeys;
    public float LCoolDownTime, RCoolDownTime;

    private PlayerInputController _controller;
    private Player player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

    private bool lefttalent = true,
    righttalent = true;

    private void Start()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        player = GetComponentInParent<Player>();
        PumpPanel.SetActive(true);

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
    }

    private void PressTalent()
    {
        if (_controller != null && _controller.LeftTalent && lefttalent) SelectTalentActive(0);

        if (_controller != null && _controller.RightTalent && righttalent) SelectTalentActive(1);
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

    private void Talent()
    {
        switch (f_index)
        {
            case 0:
                Shotgunspread();
                StartCoroutine(LCoolDown());
                break;
            case 1:
                StartCoroutine(RCoolDown());
                break;
            default:
                Debug.Log("Dont Press");
                break;
        }
    }

    private void Shotgunspread()
    {
        for (int i = 0; i < FirePos.Length; i++)
        {
            Instantiate(Bullet, FirePos[i].position, FirePos[i].rotation);
        }
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
        player.L_speed += speedAmount;
        yield return new WaitForSeconds(RCoolDownTime);
        player.L_speed -= speedAmount;
        righttalent = true;
    }
}
