using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectWizard : MonoBehaviour
{
    public string WizardName;

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

    public void SelectTalentWizard(int index)
    {
        Panel.SetActive(true);

        foreach (GameObject talent in pressKey)
        {
            talent.SetActive(false);
        }

        pressKey[index].SetActive(true);
    }

    public void SelectTalentKnife(int index)
    {
        KnifePanel.SetActive(true);

        foreach (GameObject talent in K_Press)
        {
            talent.SetActive(false);
        }

        K_Press[index].SetActive(true);
    }

    public void SelectTalentPump(int index)
    {
        PumpPanel.SetActive(true);

        foreach (GameObject talent in P_Press)
        {
            talent.SetActive(false);
        }

        P_Press[index].SetActive(true);
    }

    public void SelectTalentLaser(int index)
    {
        LAserPanel.SetActive(true);

        foreach (GameObject talent in L_Press)
        {
            talent.SetActive(false);
        }

        L_Press[index].SetActive(true);
    }

}
