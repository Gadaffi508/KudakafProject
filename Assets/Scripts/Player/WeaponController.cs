using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Gun;
    
    private CursorManager _CursorManager;
    private Player _Player;

    private void Start()
    {
        _CursorManager = GetComponent<CursorManager>();
        _Player = GetComponent<Player>();
        _CursorManager.enabled = false;
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
            _Player.İsFly = true;
        }
    }
}
