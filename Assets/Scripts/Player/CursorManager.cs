using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public float CursorSpeed;
    public GameObject CursorObj;

    public bool IsPlayerFirst;
    
    public GameObject FirePrefabs;
    public GameObject FireEffect;
    public Transform FirePos;

    private bool fire = true;

    private void Update()
    {
        if (İnputDirection() != Vector2.zero) CursorObj.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(Angle(), Vector3.forward), CursorSpeed * Time.deltaTime);

        if (PlayerInputController.Controller.FirePressed && fire)
        {
            GameObject bullet = InstateFireProperty(FirePrefabs);
            GameObject fireEffect = InstateFireProperty(FireEffect);
            Destroy(fireEffect,.5f);
            fire = false;
        }

        if (!PlayerInputController.Controller.FirePressed && IsPlayerFirst) fire = true;
        //if (!SPlayerInput.Controller.FirePressed && IsPlayerFirst) fire = true;
    }

    private Vector2 İnputDirection()
    {
        if (IsPlayerFirst)
        {
            return PlayerInputController.Controller.CursorPos.normalized;
        }
        else
        {
            //return SPlayerInput.Controller.CursorPos.normalized;
            return PlayerInputController.Controller.CursorPos.normalized;
        }
    }
    
    private float Angle() => Mathf.Atan2(-İnputDirection().x, İnputDirection().y) * Mathf.Rad2Deg;
    
    /*float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);*/

    private GameObject InstateFireProperty(GameObject InsObj) => Instantiate(InsObj,FirePos.position, FirePos.rotation);
}
