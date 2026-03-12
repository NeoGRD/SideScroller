using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float SeeVelocity;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SeeVelocity = rb.linearVelocityX * rb.linearVelocityY;
    }

}
