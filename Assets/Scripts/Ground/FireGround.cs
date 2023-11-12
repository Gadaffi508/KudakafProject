using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGround : MonoBehaviour
{
    public int FireOfDamageCount;
    public GameObject[] FireObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FireBullet"))
        {
            FireOfDamageCount++;
            if (FireOfDamageCount == 5)
            {
                foreach (GameObject fireObj in FireObj)
                {
                    fireObj.SetActive(true);
                }
            }
        }
    }
}
