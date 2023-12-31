using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int Damage = 10;

    public int playerIndex;

    public float radius;
    public float Force;
    public LayerMask LayerHit;

    Bananaman _bananaman;

    void Start()
    {
        _bananaman = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponentInChildren<Bananaman>();
        if(_bananaman != null) _bananaman.CollectBananaMine.Add(this.gameObject);
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
        //_bananaman.CollectBananaMine.Remove(this.gameObject);

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponentInParent<Player>().PlayerIndex != playerIndex)
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
            if (hitCollider.GetComponentInParent<Player>().PlayerIndex != playerIndex)
            {
                hitCollider.GetComponentInParent<PlayerHealth>().TakeDamage(Damage);
            }
            hitCollider.GetComponentInParent<Rigidbody2D>().AddForce(direction);
        }
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        explode();
        yield return new WaitForSeconds(1);

        if (_bananaman != null) _bananaman.CollectBananaMine.Remove(this.gameObject);

        Destroy(gameObject);
    }
}
