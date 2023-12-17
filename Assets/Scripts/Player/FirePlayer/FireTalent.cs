using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireTalent : MonoBehaviour
{
    [Header("Lef Talent"), Tooltip("Hight Wall")]
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
    public PlayerSelectWizard wizard;
    public float LCoolDownTime, RCoolDownTime, UCoolDownTime, DCoolDownTime;

    private Player _player;
    private int f_index;
    private int s_index;
    private bool FireOne = true;
    private bool press = false;
    private bool SecondFire = false;

    private Vector3 fireWallPos;

    private bool lefttalent = true,
    righttalent = true,
    uptalent = true,
    downtalent = true;

    private void Awake()
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

        if (_player.FirePressed && SecondFire && s_index <= 4)
        {
            InstFireBall();
            s_index++;
            SecondFire = false;
        }

        if (!_player.FirePressed && !FireOne) SecondFire = true;
    }

    private void PressTalent()
    {
        if (_player.LeftTalent && lefttalent) SelectTalentActive(0);

        if (_player.RightTalent && righttalent) SelectTalentActive(1);

        if (_player.DownTalent && downtalent) SelectTalentActive(2);

        if (_player.UpTalent && uptalent) SelectTalentActive(3);
    }

    private void SelectTalentActive(int index)
    {
        wizard.SelectTalentWizard(index,0,true);
        f_index = index;
        press = true;
        FireOne = true;

        fireWallPos = transform.position;

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
                StartCoroutine(LCoolDown());
                break;
            case 1:
                InstFireCircle();
                StartCoroutine(RCoolDown());
                break;
            case 2:
                InstFireWind();
                StartCoroutine(DCoolDown()); 
                break;
            case 3:
                InstFireBall();
                StartCoroutine(UCoolDown());
                break;
            default:
                Debug.Log("Dont Press");
                break;
        }
    }

    private void InstFireWall()
    {
        GameObject Wall = Instantiate(FireWall, FireArea(), transform.rotation);
        //Wall.GetComponent<BulletManager>().PlayerIndex = _player.PlayerIndex;
        Destroy(Wall, 1f);
    }

    private void InstFireCircle()
    {
        GameObject Circle = Instantiate(FireCircle, transform.position, transform.rotation, transform);
        //Circle.GetComponent<BulletManager>().PlayerIndex = _player.PlayerIndex;
        Destroy(Circle, 6f);
    }

    private void InstFireWind()
    {
        GameObject bullet = InstateFireProperty(FireWind);
        bullet.GetComponent<BulletManager>().PlayerIndex = _player.PlayerIndex;
    }

    private void InstFireBall()
    {
        GameObject bullet = InstateFireProperty(FirePrefabs);
        bullet.GetComponent<BulletManager>().PlayerIndex = _player.PlayerIndex;
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

    IEnumerator LCoolDown()
    {
        lefttalent = false;
        yield return new WaitForSeconds(LCoolDownTime);
        wizard.SelectTalentWizard(0, 0,false);
        lefttalent = true;
    }

    IEnumerator RCoolDown()
    {
        righttalent = false;
        yield return new WaitForSeconds(RCoolDownTime);
        wizard.SelectTalentWizard(0, 1,false);
        righttalent = true;
    }

    IEnumerator DCoolDown()
    {
        downtalent = false;
        yield return new WaitForSeconds(DCoolDownTime);
        wizard.SelectTalentWizard(0, 3,false);
        downtalent = true;
    }

    IEnumerator UCoolDown()
    {
        uptalent = false;
        yield return new WaitForSeconds(UCoolDownTime);
        wizard.SelectTalentWizard(0, 2,false);
        uptalent = true;
    }
}
