using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Header("Random Gun")]
    public int _Random;
    public Sprite[] Sprites;
    public GameObject GunObj;

    private void Start()
    {
        _Random = Random.RandomRange(0, Sprites.Length);
        GunObj.GetComponent<SpriteRenderer>().sprite = Sprites[_Random];
    }

    private float presskey = 0;

    public void SelectTalentWizard(int index,int a_index, bool isAc)
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

    public void SelectTalentKnife(int index,int a_index, bool isAc)
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

    public void SelectTalentLaser(int index, int a_index,bool isAc)
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

        if (presskey > 0)
        {
            Circles[0].SetActive(false);
        }
        if (presskey > 1)
        {
            Circles[1].SetActive(false);
            PressPanel.SetActive(false);
        }
    }

}
