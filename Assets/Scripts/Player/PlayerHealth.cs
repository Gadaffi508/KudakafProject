using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    Player player;
    public PlayerSelectWizard selectPlayer;

    public float player�ndexd;

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
        Debug.Log("�len " + player.PlayerIndex);
        selectPlayer.GameOver();
    }
}
