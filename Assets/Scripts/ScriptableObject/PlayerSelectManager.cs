using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectManager : MonoBehaviour
{
    public Image SelectPlayerSprite;

    public List<PlayerData> PlayerDatas = new List<PlayerData>();

    public int PlayerIndex;

    public void PlayerNextSprite()
    {
        PlayerIndex++;
        if (PlayerIndex > PlayerDatas.Count - 1) PlayerIndex = 0;
        UpdateSelectPlayer();
    }
    
    public void PlayerBackSprite()
    {
        PlayerIndex--;
        if (PlayerIndex < 0) PlayerIndex = PlayerDatas.Count - 1;
        UpdateSelectPlayer();
    }

    public void UpdateSelectPlayer() => SelectPlayerSprite.sprite = PlayerDatas[PlayerIndex].PlayerSprite;
}
