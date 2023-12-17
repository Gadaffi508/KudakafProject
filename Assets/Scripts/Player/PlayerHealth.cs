using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    Player player;
    public PlayerSelectWizard selectPlayer;
    private int WinPlayer;

    private void Start()
    {
        player = GetComponent<Player>();
        selectPlayer = FindObjectOfType<PlayerSelectWizard>();
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (player.PlayerIndex == 1)
        {
            WinPlayer = 0;
        }
        if (player.PlayerIndex == 0)
        {
            WinPlayer = 1;
        }

        selectPlayer.GameOver(WinPlayer);
    }
}
