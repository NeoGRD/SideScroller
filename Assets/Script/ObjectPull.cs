using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectPull : MonoBehaviour
{
    public Transform myTransform;
    public Rigidbody2D rb;

    public Telekinesis tk;
    public PlayerMovementPlatformer Maaike;

    public int objectWeight;

    public bool canBreak;
    public float magnitude = 10;

    public bool outline = false;
    public GameObject OutlineObj;

    void Start()
    {
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Maaike = FindFirstObjectByType<PlayerMovementPlatformer>();
        tk = FindFirstObjectByType<Telekinesis>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!outline)
        {
            OutlineObj.SetActive(false);
        }
        else OutlineObj.SetActive(true);
    }

    public bool CanHurt()
    {
        if (rb.linearVelocity.magnitude >= magnitude)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnMouseDown()
    {
        rb.linearVelocity = (myTransform.position - Maaike.transform.position).normalized * tk.throwForce / objectWeight;
    }

    private void OnMouseOver()
    {
        outline = true;
    }
    private void OnMouseExit()
    {
        outline = false;
    }

}
