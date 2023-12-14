using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [Header("Line Options")]
    public LineRenderer lineRenderer;
    public LineRenderer[] LineRs;
    public Transform LineFirePos;
    public Transform[] LinePosRs;

    [Header("Cool Down Panel")]
    public GameObject LaserPanel;
    public GameObject[] PressKeys;
    public float LCoolDownTime, RCoolDownTime;

    public bool isFirstPerson = true;
    Vector2 lineEnd;

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

        if (!righttalent) LaserShortAttack();

        lineEnd = LineFirePos.position + LinePos();

        RaycastHit2D hit = Physics2D.Linecast(LineFirePos.position, lineEnd);

        if (hit.collider != null)
        {
            lineEnd = hit.point;
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
        foreach (var line in LineRs)
        {
            line.enabled = true;
        }

        for (int i = 0; i < LineRs.Length; i++)
        {
            LineRs[i].SetPosition(0, LinePosRs[i].position);
            LineRs[i].SetPosition(1, LinePosRs[i].position + LinePos());
        }
    }

    public void LaserShortAttack()
    {
        lineRenderer.enabled = true;

        // LineRenderer'ýn pozisyonlarýný ayarla
        lineRenderer.SetPosition(0, LineFirePos.position);
        lineRenderer.SetPosition(1, lineEnd);
    }

    IEnumerator LCoolDown()
    {
        lefttalent = false;
        yield return new WaitForSeconds(LCoolDownTime);
        foreach (var line in LineRs)
        {
            line.enabled = false;
        }
        lefttalent = true;
    }

    IEnumerator RCoolDown()
    {
        righttalent = false;
        yield return new WaitForSeconds(RCoolDownTime);
        lineRenderer.enabled = false;
        righttalent = true;
    }

    private bool Attack() => isFirstPerson && _controller.FirePressed || !isFirstPerson && _scontroller.SFirePressed;

    private Vector3 LinePos()
    {
        float angle = LineFirePos.eulerAngles.z;

        Vector3 laserDirection = Quaternion.Euler(0, 0, angle - 45) * Vector3.right * 20;

        return laserDirection;
    }
}
