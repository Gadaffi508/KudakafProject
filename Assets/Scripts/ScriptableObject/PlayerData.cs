using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObject/Player Data")]
public class PlayerData : ScriptableObject
{
    public string PlayerName;
    public int PlayerId;
    public Sprite PlayerSprite;
}
