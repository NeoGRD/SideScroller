using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{

    public PlayerMovementPlatformer player;
    public Transform tf;
    public float bulletLifetime;
    public float bulletSpeed;
    public float rotationSpeed;
    public float shootSpeed;


    void Start()
    {
        player = FindFirstObjectByType<PlayerMovementPlatformer>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        tf.Rotate(0,0, rotationSpeed);
    }
}
