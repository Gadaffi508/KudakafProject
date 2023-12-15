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
    [Header("Cool Down Panel")]
    public PlayerSelectWizard wizard;
    public float LCoolDownTime, RCoolDownTime;

    private Player _player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

    private bool lefttalent = true,
    righttalent = true;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        wizard = FindObjectOfType<PlayerSelectWizard>();
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
        if (_player != null && _player.LeftTalent && lefttalent) SelectTalentActive(0);

        if (_player != null && _player.RightTalent && righttalent) SelectTalentActive(1);
    }

    private void SelectTalentActive(int index)
    {
        wizard.SelectTalentPump(index);
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
        _player.L_speed += speedAmount;
        yield return new WaitForSeconds(RCoolDownTime);
        _player.L_speed -= speedAmount;
        righttalent = true;
    }
}
