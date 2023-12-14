using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpManager : MonoBehaviour
{
    public Transform PumpPos;

    private void Update()
    {
        float rotationZ = PumpPos.rotation.eulerAngles.z;

        if (rotationZ > 0 && rotationZ < 180) transform.localScale = GunScale(-1);
        else transform.localScale = GunScale(1);
    }

    private Vector3 GunScale(int X) => new Vector3(1f, X, 1f);
}
