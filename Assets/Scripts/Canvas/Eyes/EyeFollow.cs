using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public float amount = 1.5f;
    public float speed = 10;

    void Update()
    {
        transform.localPosition = LocalPos();
    }

    private Vector3 LocalPos()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 scenePos = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - scenePos.x, mousePos.y - scenePos.y);

        Vector3 dir = transform.TransformDirection(offset).normalized;

        return Vector3.Lerp(transform.localPosition, dir * amount, Time.deltaTime * speed);
    }
}
