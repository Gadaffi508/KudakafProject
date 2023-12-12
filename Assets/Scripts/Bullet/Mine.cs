using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    Bananaman _bananaman;

    void Start()
    {
        _bananaman = GameObject.FindGameObjectWithTag("Moonkey").gameObject.GetComponent<Bananaman>();
        _bananaman.CollectBananaMine.Add(this.gameObject);
    }

    private void Update()
    {
        if (BorderX() || BorderY())
        {
            _bananaman.CollectBananaMine.Remove(this.gameObject);

            Destroy(gameObject);
        }
    }

    public void Collection()
    {
        Destroy(gameObject);
    }

    private bool BorderX() => transform.position.x < -10 || transform.position.x > 10;

    private bool BorderY() => transform.position.y < -6 || transform.position.y > 6;
}
