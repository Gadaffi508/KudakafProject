using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGround : MonoBehaviour
{
    public int FireOfDamageCount;
    public GameObject[] FireObj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FireBullet"))
        {
            FireOfDamageCount++;
            if (FireOfDamageCount == 3)
            {
                foreach (GameObject fireObj in FireObj)
                {
                    fireObj.SetActive(true);
                }

                Invoke("OffFire",5);
            }
        }
    }

    private void OffFire()
    {
        foreach (GameObject fireObj in FireObj)
        {
            fireObj.SetActive(false);
            FireOfDamageCount = 0;
        }
    }
}
