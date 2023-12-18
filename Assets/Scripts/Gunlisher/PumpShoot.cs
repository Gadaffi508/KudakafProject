using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PumpShoot : MonoBehaviour
{
    public Transform _playerSprite;
    public Transform PumpPos;

    [Header("Lef Talent"), Tooltip("Shotgun blast spread")]
    public GameObject Bullet;
    public Transform[] FirePos;

    [Header("Right Talent"), Tooltip("Heal")]
    public int HealAmount;
    public float speedAmount;

    [Header("Up Talent"), Tooltip("Classic Bomb")]
    public GameObject Bomb;

    [Header("Cool Down Panel")]
    public PlayerSelectWizard wizard;
    public float LCoolDownTime, RCoolDownTime, UCoolDownTime;

    private Player _player;
    private PlayerHealth _playerHealth;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;
    public PlayerSpiteManager _playerSpiteManager;

    private int s_index;
    private bool SecondFire = false;

    private bool lefttalent = true,
    righttalent = true,
    uptalent = true;

    private float pumptime = 0;

    Rigidbody2D rb;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        _playerHealth = GetComponentInParent<PlayerHealth>();
        wizard = FindObjectOfType<PlayerSelectWizard>();
        rb = GetComponentInParent<Rigidbody2D>();
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

        if (_player.FirePressed && SecondFire && s_index <= 99)
        {
            Shotgunspread();
            s_index++;
            SecondFire = false;
        }

        pumptime += Time.deltaTime;
        if (!_player.FirePressed && !FireOne && pumptime > 1.85f)
        {
            SecondFire = true;
            pumptime = 0;
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

        if (index == 0)
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

    private GameObject InstateFireProperty(GameObject InsObj)
    {
        GameObject bomb = Instantiate(InsObj, FirePos[0].position, FirePos[0].rotation);

        bomb.GetComponent<BombTalena>().PlayerIndex = _player.PlayerIndex;

        return bomb;
    }

    private void Shotgunspread()
    {
        for (int i = 0; i < FirePos.Length; i++)
        {
            GameObject bullet = Instantiate(Bullet, FirePos[i].position, FirePos[i].rotation);
        }

        float rotationZ = PumpPos.rotation.eulerAngles.z;

        if (rotationZ > 0 && rotationZ < 180) rb.AddForce(Vector2.right * 1 * 1000);
        else  rb.AddForce(Vector2.right * -1 * 1000);
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
        _playerHealth.health += HealAmount;
        yield return new WaitForSeconds(RCoolDownTime);
        wizard.SelectTalentPump(0, 1, false);
        _player.L_speed -= speedAmount;
        righttalent = true;
    }
}
