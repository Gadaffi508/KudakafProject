using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransistionsManager : MonoBehaviour
{
    public Transform TransistionsPos;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = TransistionPosConvert(other.transform);
        }
    }

    private Vector2 TransistionPosConvert(Transform player) => new Vector2(TransistionsPos.position.x,player.position.y);
}
