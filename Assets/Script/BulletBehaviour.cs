using System.Collections;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;
    public void Launch()
    {
        rb.linearVelocity = transform.up * bulletSpeed;
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() || collision.gameObject.GetComponent<BulletBehaviour>())
        {
            return;
        }
        else Destroy(gameObject);
    }
}

