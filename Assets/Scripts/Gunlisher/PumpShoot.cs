using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [Header("Up Talent"), Tooltip("Classic Bomb")]
    public GameObject Bomb;

    [Header("Cool Down Panel")]
    public PlayerSelectWizard wizard;
    public float LCoolDownTime, RCoolDownTime, UCoolDownTime;

    private Player _player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;
    public PlayerSpiteManager _playerSpiteManager;

    private bool lefttalent = true,
    righttalent = true,
    uptalent = true;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        wizard = FindObjectOfType<PlayerSelectWizard>();

        _playerSpiteManager.isBlackPlayer = false;
    }

    private void Update()
    {
        PressTalent();

        if (_player.FirePressed && FireOne && press)
        {
            Talent();
            FireOne = false;
        }
    }

    private void PressTalent()
    {
        if (_player.LeftTalent && lefttalent) SelectTalentActive(0);

        if (_player.RightTalent && righttalent) SelectTalentActive(1);

        if (_player.UpTalent && uptalent) SelectTalentActive(2);
    }

    private void SelectTalentActive(int index)
    {
        wizard.SelectTalentPump(index, 0, true);
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
            case 2:
                InstateFireProperty(Bomb);
                StartCoroutine(UCoolDown());
                break;
            default:
                Debug.Log("Dont Press");
                break;
        }
    }

    private GameObject InstateFireProperty(GameObject InsObj) => Instantiate(InsObj, FirePos[0].position, FirePos[0].rotation);

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
        wizard.SelectTalentPump(0, 0, false);
        lefttalent = true;
    }

    IEnumerator UCoolDown()
    {
        uptalent = false;
        yield return new WaitForSeconds(UCoolDownTime);
        wizard.SelectTalentPump(0, 2, false);
        uptalent = true;
    }

    IEnumerator RCoolDown()
    {
        righttalent = false;
        _player.L_speed += speedAmount;
        yield return new WaitForSeconds(RCoolDownTime);
        wizard.SelectTalentPump(0, 1, false);
        _player.L_speed -= speedAmount;
        righttalent = true;
    }
}
