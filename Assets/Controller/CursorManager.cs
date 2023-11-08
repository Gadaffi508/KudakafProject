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
        CursorObj.transform.Rotate(CursorMovement());
    }
    
    private Vector3 CursorMovement() => new Vector3(0,0,-PlayerInputController.Controller.CursorPos.x * Time.deltaTime * CursorSpeed);
}
