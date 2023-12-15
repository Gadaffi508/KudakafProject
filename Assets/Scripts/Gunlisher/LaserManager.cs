using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    [Header("Line Options")]
    public LineRenderer lineRenderer;
    public LineRenderer[] LineRs;
    public Transform LineFirePos;
    public Transform[] LinePosRs;

    [Header("Up Talent"), Tooltip("Classic Bomb")]
    public GameObject Bomb;

    [Header("Cool Down Panel")]
    public PlayerSelectWizard wizard;
    public float LCoolDownTime, RCoolDownTime,UCoolDownTime;

    Vector2 lineEnd;

    private Player _player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;
    public PlayerSpiteManager _playerSpiteManager;

    private bool lefttalent = true,
    righttalent = true,
    upTalent = true;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        wizard = FindObjectOfType<PlayerSelectWizard>();
        _playerSpiteManager.isBlackPlayer = false;
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        PressTalent();

        if (_player.FirePressed && FireOne && press)
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
        if (_player.LeftTalent && lefttalent) SelectTalentActive(0);

        if (_player.RightTalent && righttalent) SelectTalentActive(1);

        if (_player.UpTalent && upTalent) SelectTalentActive(2);
    }

    private void SelectTalentActive(int index)
    {
        wizard.SelectTalentLaser(index);
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
            case 2:
                InstateFireProperty(Bomb);
                StartCoroutine(UCoolDown());
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

    private GameObject InstateFireProperty(GameObject InsObj) => Instantiate(InsObj, LineFirePos.position, LineFirePos.rotation);

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

    IEnumerator UCoolDown()
    {
        upTalent = false;
        yield return new WaitForSeconds(UCoolDownTime);
        upTalent = true;
    }

    private Vector3 LinePos()
    {
        float angle = LineFirePos.eulerAngles.z;

        Vector3 laserDirection = Quaternion.Euler(0, 0, angle - 45) * Vector3.right * 20;

        return laserDirection;
    }
}
