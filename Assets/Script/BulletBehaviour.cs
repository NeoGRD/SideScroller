using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed;
    public void Launch()
    {
        rb.linearVelocity = transform.up * bulletSpeed;
    }
}
