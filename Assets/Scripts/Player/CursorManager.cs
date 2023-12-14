using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public float CursorSpeed;
    public GameObject CursorObj;

    private void Update()
    {
        if (İnputDirection() != Vector2.zero) CursorObj.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(Angle(), Vector3.forward), CursorSpeed * Time.deltaTime);

        //if (!SPlayerInput.Controller.FirePressed && IsPlayerFirst) fire = true;
    }

    private Vector2 İnputDirection()
    {
        return PlayerInputController.Controller.CursorPos.normalized;
    }
    
    private float Angle() => Mathf.Atan2(-İnputDirection().x, İnputDirection().y) * Mathf.Rad2Deg;
    
    /*float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);*/
}
