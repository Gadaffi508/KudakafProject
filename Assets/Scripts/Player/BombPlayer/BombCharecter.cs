using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCharecter : MonoBehaviour
{
    public int Force = 150;
    public float BombTime;
    public GameObject BombPlayer;

    void OnEnable()
    {
        StartCoroutine(StartBombTimer());
    }

    IEnumerator StartBombTimer()
    {
        yield return new WaitForSeconds(BombTime);
        BombPlayer.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth health))
        {
            health.TakeDamage(10);

            Vector2 direction = collision.gameObject.transform.position - transform.position;

            direction *= Force;

            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(direction);
        }
    }
}
