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
        
        if (Energy == 0 || cc.isOnGround || !Input.GetKey(KeyCode.LeftShift))
        {
            isLevi = false;
        }

        else if (Input.GetKey(KeyCode.LeftShift) && !cc.isOnGround)
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
