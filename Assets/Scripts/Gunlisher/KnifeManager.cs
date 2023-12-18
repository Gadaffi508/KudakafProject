using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    public Transform PlayerPos;
    public Transform TosKnifePos;
    public float Radius;

    [Header("Lef Talent"), Tooltip("Toss Knife")]
    public GameObject KnifeObj;

    [Header("Right Talent"), Tooltip("Dash Obj and Damage")]
    public GameObject KnifeDash;

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

    float nextFire;
    [SerializeField] float firetime = 1;

    private void Start()
    {
        _player = GetComponentInParent<Player>();
        _playerSpiteManager.isBlackPlayer = false;
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

        Collider2D[] playerCol = Physics2D.OverlapCircleAll(TosKnifePos.position, Radius);

        foreach (Collider2D item in playerCol)
        {
            if (item != null)
            {
                if (item.gameObject.CompareTag("Player"))
                {
                    nextFire += Time.deltaTime;

                    if (nextFire > 1)
                    {
                        item.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(5);
                        nextFire = 0;
                    }
                }
            }
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
        wizard.SelectTalentKnife(index,0,true);
        f_index = index;
        press = true;
        if(!_player.FirePressed) FireOne = true;
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
            case 2:
                InstateFireProperty(Bomb, TosKnifePos);
                StartCoroutine(UCoolDown());
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
        wizard.SelectTalentKnife(0, 0,false);
        lefttalent = true;
    }

    IEnumerator UCoolDown()
    {
        uptalent = false;
        yield return new WaitForSeconds(UCoolDownTime);
        wizard.SelectTalentKnife(0, 2, false);
        uptalent = true;
    }

    IEnumerator RCoolDown()
    {
        righttalent = false;
        yield return new WaitForSeconds(RCoolDownTime);
        wizard.SelectTalentKnife(0, 1,false);
        righttalent = true;
    }

    private GameObject InstateFireProperty(GameObject InsObj, Transform FirePos)
    {
        GameObject bomb = Instantiate(InsObj, FirePos.position, FirePos.rotation);

        if (bomb.GetComponent<BombTalena>())
        {
            bomb.GetComponent<BombTalena>().PlayerIndex = _player.PlayerIndex;
        }

        return bomb;
    }

    private GameObject InstateFireProperty(GameObject InsObj, Transform FirePos, bool parent)
    {
        GameObject dashObj = Instantiate(InsObj, FirePos.position, FirePos.rotation, FirePos.parent);
        dashObj.GetComponent<Transform>().localScale = -FirePos.localScale;
        Destroy(dashObj, 1f);
        return dashObj;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(TosKnifePos.position, Radius);
    }
}
