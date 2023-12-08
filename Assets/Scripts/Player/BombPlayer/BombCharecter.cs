using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharecter : MonoBehaviour
{
    public float BombTime;
    public GameObject BombPlayer;

    void OnEnable()
    {
        StartCoroutine(StartBombTimer());
    }

    IEnumerator StartBombTimer()
    {
        yield return new WaitForSeconds(BombTime);
        BombPlayer.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
