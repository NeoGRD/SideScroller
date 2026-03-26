using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{

    public PlayerMovementPlatformer player;
    public Transform tf;
    public int bulletSpeed = 1;

    void Start()
    {
        player = FindFirstObjectByType<PlayerMovementPlatformer>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {
        tf.Rotate(0,0, -1);
    }
}
