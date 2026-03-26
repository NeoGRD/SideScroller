using UnityEngine;

public class checkPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hm = collision.GetComponent<HealthManager>();
        if (hm != null)
        {
            hm.cp = transform;
        }
    }
}
