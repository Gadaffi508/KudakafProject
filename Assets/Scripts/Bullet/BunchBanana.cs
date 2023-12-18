using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunchBanana : MonoBehaviour
{
    public Transform[] BananaFirePos;
    public GameObject Banana;
    public float BunchTime;
    public float m_Thrust;

    Rigidbody2D rb;

    private IEnumerator Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * m_Thrust);
        rb.AddForce(transform.up * m_Thrust / 2);

        yield return new WaitForSeconds(BunchTime);
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Banana, BananaFirePos[i].position, BananaFirePos[i].rotation);
        }
        Destroy(this.gameObject);
    }
}
