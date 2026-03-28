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
        yield return new WaitForSeconds(8);
        Destroy(gameObject);

    }

}

