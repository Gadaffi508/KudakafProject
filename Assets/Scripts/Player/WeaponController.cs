using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class WeaponController : MonoBehaviour
{
    public GameObject Gun;
    public GameObject[] Gunlisher;

    public GameObject FirePlayer;
    public GameObject BombPlayer;
    public GameObject Monkey;
    public GameObject ThısPlayer;

    public PlayerSelectWizard selectPlayer;
    public string WizardPlayerName;
    private Player _Player;

    private bool PlayerSelected = false;

    private bool press = false;

    private void Start()
    {
        _Player = GetComponent<Player>();
        selectPlayer = FindObjectOfType<PlayerSelectWizard>();
        WizardPlayerName = selectPlayer.WizardName;
        Gun.SetActive(false);

    }

    private void Update()
    {
        if (Input.anyKey && press == false)
        {
            selectPlayer.PressKeyPanel(1);
            press = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GunObject") && PlayerSelected == false)
        {
            Gunlisher[selectPlayer._Random].SetActive(true);

            Destroy(other.gameObject);

            PlayerSelected = true;
        }
        
        if (other.gameObject.CompareTag("BosObject") && PlayerSelected == false)
        {
            Gun.SetActive(true);

            switch (WizardPlayerName)
            {
                case "Fire":
                    FirePlayer.SetActive(true);
                    _Player.İsFly = true;
                    break;
                case "Bomb":
                    BombPlayer.SetActive(true);
                    break;
                case "Monkey":
                    Monkey.SetActive(true);
                    break;
                default:
                    break;
            }

            ThısPlayer.SetActive(false);

            PlayerSelected = true;

            Destroy(other.gameObject);
        }
    }
}
