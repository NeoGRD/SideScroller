using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class DoorBehaviour : MonoBehaviour
{
    public Animator anim;
    public bool roomCleared;
    public bool hasWave;
    public GameObject roomManager;

    void Start()
    {
        if (hasWave)
        {
            anim.Play("Opened");
        }
        if (!hasWave)
        {
            anim.Play("Closed");
        }
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            anim.Play("DoorOpen");
        }
    }

}
