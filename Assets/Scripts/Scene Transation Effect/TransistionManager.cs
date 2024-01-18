using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransistionManager : MonoBehaviour
{
    public GameObject TransistionBG;
    public Animator TransistionAnim;

    private IEnumerator Start()
    {
        TransistionAnim.SetBool("İsOpen",true);
        yield return new WaitForSeconds(.5f);
        TransistionBG.SetActive(false);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TransistionBG.SetActive(true);
            TransistionAnim.SetBool("İsOpen",false);
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
