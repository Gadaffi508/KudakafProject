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
        int random;
        do
        {
            random = Random.Range(1, SceneLenght);
        } 
        while (random == ThisScene);

        Debug.Log("Yeni Rastgele Sayý: " + random);
        SceneManager.LoadScene(random);
    }
}
