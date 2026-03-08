using UnityEngine;

public class checkPoint : MonoBehaviour
{
    public HealthManager maaike;

    void Start()
    {
        maaike = FindFirstObjectByType<HealthManager>();

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("NOAAAAAAAAAAAHDAUBFUEIugbzigubZIUGRBiugbhRIUG");
        maaike.cp = transform;
    }
}
