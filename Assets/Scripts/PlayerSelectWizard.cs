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

    [Header("Health Players")]
    public Image OnePlayer;
    public Image SecondPlayer;

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
            foreach (GameObject item in pressKey)
            {
                item.transform.localScale = new Vector2(1f, 1f);
            }

            pressKey[index].transform.localScale = new Vector2(1.3f, 1.3f);
        }

        if (!isAc)
        {
            pressKey[a_index].transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void SelectTalentKnife(int index, int a_index, bool isAc)
    {

        KnifePanel.SetActive(true);

        if (isAc)
        {
            foreach (GameObject item in K_Press)
            {
                item.transform.localScale = new Vector2(1f, 1f);
            }

            K_Press[index].transform.localScale = new Vector2(1.3f, 1.3f);
        }

        if (!isAc)
        {
            K_Press[a_index].transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void SelectTalentPump(int index, int a_index, bool isAc)
    {
        PumpPanel.SetActive(true);

        if (isAc)
        {
            foreach (GameObject item in P_Press)
            {
                item.transform.localScale = new Vector2(1f, 1f);
            }

            P_Press[index].transform.localScale = new Vector2(1.3f, 1.3f);

        }

        if (!isAc)
        {
            P_Press[a_index].transform.localScale = new Vector2(1f, 1f);
        }
    }

    public void SelectTalentLaser(int index, int a_index, bool isAc)
    {
        LAserPanel.SetActive(true);

        if (isAc)
        {
            foreach (GameObject item in L_Press)
            {
                item.transform.localScale = new Vector2(1f, 1f);
            }

            L_Press[index].transform.localScale = new Vector2(1.3f, 1.3f);
        }

        if (!isAc)
        {
            L_Press[a_index].transform.localScale = new Vector2(1f, 1f);
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

    public void GameOver(int winplayerýndex)
    {
        if (winplayerýndex == 0 && Plus == false)
        {
            onePlayerWincount++;
            PlayerPrefs.SetInt("onePlayerWincount", onePlayerWincount);
            Plus = true;
        }

        if (winplayerýndex == 1 && Plus == false)
        {
            SecondPlayerWincount++;
            PlayerPrefs.SetInt("SecondPlayerWincount", SecondPlayerWincount);
            Plus = true;
        }
        CanvasPanel.SetActive(true);

        winText.text = $"{SecondPlayerWincount} {onePlayerWincount}";

        if (onePlayerWincount > 1)
        {
            winText.text = "Winner Player 0";
        }

        if (SecondPlayerWincount > 1)
        {
            winText.text = "Winner Player 1";
        }
    }

    public void HealthBarImage(int playerIndex,int damage,int HealthCount)
    {
        float healthPercentage = (float)(HealthCount) / 100;

        if (playerIndex == 0)
        {
            OnePlayer.fillAmount = healthPercentage;
        }

        if (playerIndex == 1)
        {
            SecondPlayer.fillAmount = healthPercentage;
        }
    }

}
