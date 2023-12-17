using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputHandler : MonoBehaviour
{
    public static PlayerInputHandler playerInputHandler;

    private PlayerInput playerInput;
    private Player _Player;
    string[] joystickNames;

    private void Start()
    {
        joystickNames = Input.GetJoystickNames();

        _Player = GetComponent<Player>(); 
        _Player.PlayerGamePadName = joystickNames[0];

        playerInput = GetComponent<PlayerInput>();
        var playerindex = playerInput.playerIndex;

        Debug.Log(playerindex);
    }
}
