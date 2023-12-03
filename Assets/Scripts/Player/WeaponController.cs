using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Gun;
    
    public CursorManager _CursorManager;
    private Player _Player;
    private SPlayer _SPlayer;

    private void Start()
    {
        if(_Player != null) _Player = GetComponent<Player>();
        if(_SPlayer != null) _SPlayer = GetComponent<SPlayer>();
        Gun.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GunObject"))
        {
            _CursorManager.enabled = true;
            Gun.SetActive(true);
        }
        
        if (other.gameObject.CompareTag("BosObject"))
        {
            if(_Player != null) _Player.İsFly = true;
            if(_SPlayer != null) _SPlayer.İsFly = true;
        }
    }
}
