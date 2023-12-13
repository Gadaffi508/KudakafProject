using System;
using System.Collections;
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
    public GameObject KnifePanel;
    public GameObject[] PressKeys;
    public float LCoolDownTime, RCoolDownTime;

    public bool isFirstPerson = true;

    private PlayerInputController _controller;
    private SPlayerInput _scontroller;
    private Player player;
    private int f_index;
    private bool FireOne = true;
    private bool press = false;

    private bool lefttalent = true,
    righttalent = true;

    private void Start()
    {
        _controller = GetComponentInParent<PlayerInputController>();
        _scontroller = GetComponentInParent<SPlayerInput>();
        player = GetComponentInParent<Player>();
        KnifePanel.SetActive(true);

        foreach (GameObject key in PressKeys)
        {
            key.SetActive(false);
        }
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
                StartCoroutine(player.Dash());
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

    private bool Attack() => isFirstPerson && _controller.FirePressed || !isFirstPerson && _scontroller.SFirePressed;
}
