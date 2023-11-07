using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public float CursorSpeed;

    public float MinX, MaxX;
    public float MinY, MaxY;

    private void Update()
    {
        transform.Translate(CursorMovement());
        transform.position = CursorRestriction();
    }
    
    private Vector3 CursorMovement() => PlayerInputController.Controller.CursorPos * Time.deltaTime * CursorSpeed;
    
    private Vector2 CursorRestriction() => new Vector2(Mathf.Clamp(transform.position.x,MinX,MaxX),Mathf.Clamp(transform.position.y,MinY, MaxY));
}
