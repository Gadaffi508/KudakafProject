using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectWizard : MonoBehaviour
{
    public string WizardName;

    public Transform[] PlayerOneStartPos;

    public GameObject PressPanel;
    public GameObject[] Circles;

    [Header("Wizard")]
    public GameObject Panel;
    public GameObject[] pressKey;

    [Header("Fighter")]
    public GameObject KnifePanel;
    public GameObject[] K_Press;
    public GameObject PumpPanel;
    public GameObject[] P_Press;
    public GameObject LAserPanel;
    public GameObject[] L_Press;

    private float presskey = 0;

    [Header("Random Gun")]
    public int _Random;
    public Sprite[] Sprites;
    public GameObject GunObj;

    [Header("Game Over Options")]
    public GameObject CanvasPanel;
    public List<WeaponController> playerList = new List<WeaponController>();

    [Header("Win player")]
    public int onePlayerWincount = 0;
    public int SecondPlayerWincount = 0;
    public Text winText;

    private bool Plus = false;

    private void Start()
    {
        _Random = Random.RandomRange(0, Sprites.Length);
        GunObj.GetComponent<SpriteRenderer>().sprite = Sprites[_Random];
        onePlayerWincount = PlayerPrefs.GetInt("onePlayerWincount");
        SecondPlayerWincount = PlayerPrefs.GetInt("SecondPlayerWincount");
    }


    public void SelectTalentWizard(int index, int a_index, bool isAc)
    {
        Panel.SetActive(true);

        if (isAc)
        {
            pressKey[index].SetActive(false);
        }

        if (!isAc)
        {
            pressKey[a_index].SetActive(true);
        }
    }

    public void SelectTalentKnife(int index, int a_index, bool isAc)
    {
        KnifePanel.SetActive(true);

        if (isAc)
        {
            K_Press[index].SetActive(false);
        }

        if (!isAc)
        {
            K_Press[a_index].SetActive(true);
        }
    }

    public void SelectTalentPump(int index, int a_index, bool isAc)
    {
        PumpPanel.SetActive(true);

        if (isAc)
        {
            P_Press[index].SetActive(false);
        }

        if (!isAc)
        {
            P_Press[a_index].SetActive(true);
        }
    }

    public void SelectTalentLaser(int index, int a_index, bool isAc)
    {
        LAserPanel.SetActive(true);

        if (isAc)
        {
            L_Press[index].SetActive(false);
        }

        if (!isAc)
        {
            L_Press[a_index].SetActive(true);
        }
    }

    public void PressKeyPanel(int index)
    {
        presskey += index;

        if (presskey == 1)
        {
            Circles[0].SetActive(false);
        }
        if (presskey == 2)
        {
            Circles[1].SetActive(false);
            PressPanel.SetActive(false);
        }
    }

    public void GameOver(int winplayer�ndex)
    {
        if (winplayer�ndex == 0 && Plus==false)
        {
            onePlayerWincount++;
            PlayerPrefs.SetInt("onePlayerWincount", onePlayerWincount);
            Plus = true;
        }

        if (winplayer�ndex == 1 && Plus == false)
        {
            SecondPlayerWincount++;
            PlayerPrefs.SetInt("SecondPlayerWincount", SecondPlayerWincount);
            Plus = true;
        }
        CanvasPanel.SetActive(true);

        winText.text = $"{onePlayerWincount} {SecondPlayerWincount}";

        if (onePlayerWincount > 1)
        {
            winText.text = "Winner Player 0";
        }

        if (SecondPlayerWincount>1)
        {
            winText.text = "Winner Player 1";
        }
    }

}
