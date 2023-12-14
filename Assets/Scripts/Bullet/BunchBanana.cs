using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunchBanana : MonoBehaviour
{
    public Transform[] BananaFirePos;
    public GameObject Banana;
    public float BunchTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(BunchTime);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Banana, BananaFirePos[i].position, BananaFirePos[i].rotation);
        }
        Destroy(this.gameObject);
    }
}
