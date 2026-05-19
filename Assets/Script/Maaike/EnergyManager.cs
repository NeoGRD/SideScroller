using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    
    public PlayerMovementPlatformer cc;
    public float Energy = 3f;

    public bool isLevi;

    void Start()
    {
        cc = FindFirstObjectByType<PlayerMovementPlatformer>();
    }
    void Update()
    {
        
        if (Energy == 0 || cc.isOnGround || !Input.GetMouseButton(1))
        {
            isLevi = false;
        }

        else if (Input.GetMouseButton(1) && !cc.isOnGround)
        {
            Energy -= Time.deltaTime;// * 45;
            if (Energy > 0 && Energy <= 3f)
            {
                isLevi = true;
            }
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
