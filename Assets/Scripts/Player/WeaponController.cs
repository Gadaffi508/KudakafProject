using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public GameObject Gun;
    public GameObject Gunlisher;
    public GameObject BosPlayer;
    public GameObject ThısPlayer;
    public bool FirePlayer = false;

    private Player _Player;
    private SPlayer _SPlayer;

    private void Start()
    {
        _Player = GetComponent<Player>();
        _SPlayer = GetComponent<SPlayer>();
        Gun.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GunObject"))
        {
            Gunlisher.SetActive(true);

            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("BosObject"))
        {
            Gun.SetActive(true);

            if (_Player != null && FirePlayer) _Player.İsFly = true;
            if(_SPlayer != null && FirePlayer) _SPlayer.İsFly = true;

            BosPlayer.SetActive(true);
            ThısPlayer.SetActive(false);

            Destroy(other.gameObject);
        }
    }
}
