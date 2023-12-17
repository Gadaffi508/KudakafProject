using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputHandler : MonoBehaviour
{
    string[] joystickNames;
    public List<Player> player = new List<Player>();

    int index = 0;
    bool plused = false;

    private void Start()
    {
        joystickNames = Input.GetJoystickNames(); 
    }

    private void Update()
    {
        if (player.Count > 0 && plused == false)
        {
            GamePadNumber();
            index++;
            plused = true;
        }

        if (player.Count > 1)
        {
            GamePadNumber();
        }

    }

    public void GamePadNumber()
    {
        for (int i = index; i < index+1; i++)
        {
            player[i].PlayerIndex = i;
        }
    }
}
