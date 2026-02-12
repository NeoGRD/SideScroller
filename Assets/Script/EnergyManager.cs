using UnityEngine;

public class EnergyManager : MonoBehaviour
{

    public PlayerMovementPlatformer cc;
    public float Energy = 3f;

    

    void Start()
    {
        cc = FindFirstObjectByType<PlayerMovementPlatformer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !cc.isOnGround)
        {
            Energy -= Time.deltaTime;// * 45;
        }

        if (cc.isOnGround)
        {
            Energy += Time.deltaTime;// * 45;
        }

        if (Energy < 0)
        {
            Energy = 0;
        }

        if (Energy > 3f)
        {
            Energy = 3f;
        }


    }
}
