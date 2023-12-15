using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Player player;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        var Players = FindObjectsOfType<Player>();
        var ýndex = playerInput.playerIndex;
        player = Players.FirstOrDefault(m => m.GetPlayerIndex() == ýndex);
    }
}
