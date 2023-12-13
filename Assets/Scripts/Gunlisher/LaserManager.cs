using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [Header("Line Options")]
    public LineRenderer lineRenderer;
    public Transform LineFirePos;

    [Header("Cool Down Panel")]
    public GameObject LaserPanel;
    public GameObject[] PressKeys;
    public float LCoolDownTime, RCoolDownTime;

    public bool isFirstPerson = true;

    private PlayerInputController _controller;
    private SPlayerInput _scontroller;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

    private bool lefttalent = true,
    righttalent = true;

    private void Start()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        _scontroller = GetComponentInParent<SPlayerInput>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        LaserPanel.SetActive(true);

        foreach (GameObject key in PressKeys)
        {
            key.SetActive(false);
        }

        lineRenderer.enabled = false;
    }

    private void Update()
    {
        PressTalent();

        if (Attack() && FireOne && press)
        {
            Talent();
            FireOne = false;
        }
    }

    private void PressTalent()
    {
        if (_controller.LeftTalent && lefttalent) SelectTalentActive(0);

        if (_controller.RightTalent && righttalent) SelectTalentActive(1);
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
                LaserNearAttack();
                StartCoroutine(LCoolDown());
                break;
            case 1:
                LaserShortAttack();
                StartCoroutine(RCoolDown());
                break;
            default:
                Debug.Log("Dont Press");
                break;
        }
    }

    public void LaserNearAttack()
    {
        LaserShortAttack();

        StartCoroutine(StartLaserAttack());
    }

    public void LaserShortAttack()
    {
        lineRenderer.enabled = true;

        float angle = LineFirePos.eulerAngles.z;

        // Lazerin çýkýþ yönünü hesapla
        Vector3 laserDirection = Quaternion.Euler(0, 0, angle - 45) * Vector3.right * 20;

        // LineRenderer'ýn pozisyonlarýný ayarla
        lineRenderer.SetPosition(0, LineFirePos.position);
        lineRenderer.SetPosition(1, LineFirePos.position + laserDirection);
    }

    IEnumerator StartLaserAttack()
    {
        yield return new WaitForSeconds(1);
        lineRenderer.SetWidth(0.5f, 0.5f);
        yield return new WaitForSeconds(2);
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.enabled = false;
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

    private bool Attack() => isFirstPerson && _controller.FirePressed || !isFirstPerson && _scontroller.SFirePressed;
}
