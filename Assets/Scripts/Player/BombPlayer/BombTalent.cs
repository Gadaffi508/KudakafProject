using System.Collections;
using UnityEngine;

public class BombTalent : MonoBehaviour
{
    public Transform Cursor;

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
    public float LCoolDownTime, RCoolDownTime, DCoolDownTime;

    private PlayerInputController _controller;
    private int f_index;
    private int S_index = 1;
    private bool FireOne = true;
    private bool press = false;
    private bool SecondFire = false;

    private bool lefttalent = true,
    righttalent = true,
    downtalent = true;

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

        if (_controller != null && _controller.FirePressed && FireOne && press)
        {
            Talent();
            FireOne = false;
            S_index++;
            SecondFire = false;
        }

        if (_controller != null && _controller.FirePressed && SecondFire && S_index == 1)
        {
            InstBomb(C_Bomb);
            S_index++;
            SecondFire = false;
        }

        if (_controller != null && !_controller.FirePressed && !FireOne) SecondFire = true;
    }

    private void Talent()
    {
        switch (f_index)
        {
            case 0:
                InstBomb(B_Bomb);
                StartCoroutine(LCoolDown());
                break;
            case 1:
                InstBomb(C_Bomb);
                StartCoroutine(RCoolDown());
                break;
            case 2:
                InstBomb(H_Bomb);
                StartCoroutine(DCoolDown());
                break;
            case 3:
                SwitchCharecter();
                break;
        }
    }

    private void PressTalent()
    {
        if (_controller != null && _controller.LeftTalent && lefttalent) ActiveTalent(0);

        if (_controller != null && _controller.RightTalent && righttalent) ActiveTalent(1);

        if (_controller != null && _controller.DownTalent && downtalent) ActiveTalent(2);

        if (_controller != null && _controller.UpTalent) ActiveTalent(3);
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
        GameObject bombObj = Instantiate(bomb, FirePos.position, FirePos.rotation);
        if (Cursor.rotation.z > 0 && Cursor.rotation.z < 180)
        {
            bombObj.GetComponent<BulletManager>().Scale();
        }
    }

    private void SwitchCharecter()
    {
        lefttalent = true;
        righttalent = true;
        downtalent = true;
        this.gameObject.SetActive(false);
        BombCharecter.SetActive(true);
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
        downtalent = false;
        yield return new WaitForSeconds(DCoolDownTime);
        downtalent = true;
    }
}
