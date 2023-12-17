using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float radius;
    public float Force;
    public LayerMask LayerHit;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Timer());
        }
    }

    private bool BorderX() => transform.position.x < -10 || transform.position.x > 10;

    private bool BorderY() => transform.position.y < -6 || transform.position.y > 6;

    public void explode()
    {
        Collider2D[] rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, LayerHit);

        foreach (Collider2D hitCollider in rayInfo)
        {
            Vector2 direction = hitCollider.transform.position - transform.position;

            direction *= Force;

            hitCollider.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            hitCollider.GetComponentInParent<Rigidbody2D>().AddForce(direction);
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        explode();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
