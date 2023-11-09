using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public float CursorSpeed;
    public GameObject CursorObj;

    public GameObject FirePrefabs;
    public Transform FirePos;

    private bool fire = true;

    private void Update()
    {
        CursorObj.transform.Rotate(CursorMovement());

        if (PlayerInputController.Controller.FirePressed && fire)
        {
            GameObject bullet = Instantiate(FirePrefabs, FirePos.position, FirePos.rotation);
            fire = false;
        }

        if (!PlayerInputController.Controller.FirePressed) fire = true;
    }

    private Vector3 CursorMovement() => new Vector3(0,0,(-PlayerInputController.Controller.CursorPos.x + PlayerInputController.Controller.CursorPos.y) * Time.deltaTime * CursorSpeed);
}
