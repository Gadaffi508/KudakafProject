using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMap : MonoBehaviour
{
    public int SceneLenght;
    public int ThisScene;

    public void RandomGameMapFnc()
    {
        int random = Random.Range(1, SceneLenght+1);

        Debug.Log("Yeni Rastgele Sayý: " + random);
        SceneManager.LoadScene(random);
    }

    public void LoadScene(int SceneÝd)
    {
        SceneManager.LoadScene(SceneÝd);
    }

    public void GameTimeScale(int ScaleHeight)
    {
        Time.timeScale = ScaleHeight;
    }

    public void QuýtGame()
    {
        Application.Quit();
    }
}
