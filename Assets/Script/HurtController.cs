using UnityEngine;

public class HurtController : MonoBehaviour
{
    public HealthManager hm;
    public int damage;
    void Start()
    {
        hm = FindFirstObjectByType<HealthManager>();
    }



    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hm = collision.gameObject.GetComponent<HealthManager>();
        if (hm != null)
        {
            hm.AddHp(-9000);
        }
    }
}
