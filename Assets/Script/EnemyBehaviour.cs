using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{

    public PlayerMovementPlatformer player;
    public Transform tf;
    public float bulletLifetime;
    public float bulletSpeed;
    public float rotationSpeed;
    public float shootSpeed;
    //public bool canAim = false;
    //public Transform targetTf;
    // private bool isAiming;


    void Start()
    {
        player      = FindFirstObjectByType<PlayerMovementPlatformer>();
        targetTf    = FindFirstObjectByType<PlayerMovementPlatformer>().transform;
        tf          = GetComponent<Transform>();
    }

    void Update()
    {
        //if (isAiming)
        //{
        //    tf.Rotate(0,0, rotationSpeed);
        //}
        //else
        //{
        //   transform.LookAt(targetTf);
        //}
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    isAiming = true;
    //}

}
