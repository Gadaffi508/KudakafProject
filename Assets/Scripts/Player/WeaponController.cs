using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController : MonoBehaviour
{
    public GameObject Gun;
    public GameObject BosPlayer;
    public GameObject ThısPlayer;
    public CursorManager _CursorManager;
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
            _CursorManager.enabled = true;
            Gun.SetActive(true);

            Destroy(other.gameObject);
        }
        
        if (other.gameObject.CompareTag("BosObject"))
        {
            if(_Player != null && FirePlayer) _Player.İsFly = true;
            if(_SPlayer != null && FirePlayer) _SPlayer.İsFly = true;

            BosPlayer.SetActive(true);
            ThısPlayer.SetActive(false);

            Destroy(other.gameObject);
        }
    }
}
