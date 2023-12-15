using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform TosKnifePos;

    [Header("Lef Talent"), Tooltip("Toss Knife")]
    public GameObject KnifeObj;

    [Header("Right Talent"), Tooltip("Dash Obj and Damage")]
    public GameObject KnifeDash;

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
        wizard.SelectTalentKnife(index);
        f_index = index;
        press = true;
        FireOne = true;
    }

    private void Talent()
    {
        switch (f_index)
        {
            case 0:
                StartCoroutine(_player.Dash());
                InstateFireProperty(KnifeDash, PlayerPos, true);
                StartCoroutine(LCoolDown());
                break;
            case 1:
                InstateFireProperty(KnifeObj, TosKnifePos);
                StartCoroutine(RCoolDown());
                break;
            default:
                Debug.Log("Dont Press");
                break;
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
        yield return new WaitForSeconds(RCoolDownTime);
        righttalent = true;
    }

    private GameObject InstateFireProperty(GameObject InsObj, Transform FirePos) => Instantiate(InsObj, FirePos.position, FirePos.rotation);

    private GameObject InstateFireProperty(GameObject InsObj, Transform FirePos, bool parent)
    {
        GameObject dashObj = Instantiate(InsObj, FirePos.position, FirePos.rotation, FirePos.parent);
        dashObj.GetComponent<Transform>().localScale = -FirePos.localScale;
        Destroy(dashObj, 1f);
        return dashObj;
    }
}
