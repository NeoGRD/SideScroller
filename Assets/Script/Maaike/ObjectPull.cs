using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ObjectPull : MonoBehaviour
{
    //////////////////////////////////////////

    public Transform myTransform;
    public Rigidbody2D rb;

    public float TempX;
    public float TempY;
    
    //////////////////////////////////////////

    public Telekinesis tk;
    public PlayerMovementPlatformer Maaike;
    
    //////////////////////////////////////////

    public int objectWeight;
    
    //////////////////////////////////////////

    public bool canBreak;
    public float magnitude = 1;

    public float currentmagnitude;

    public bool Anchored;

    //////////////////////////////////////////

    public bool outline = false;
    public GameObject OutlineObj;

    //////////////////////////////////////////


    void Start()
    {
        myTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Maaike = FindFirstObjectByType<PlayerMovementPlatformer>();
        tk = FindFirstObjectByType<Telekinesis>();

        TempX = myTransform.position.x;
        TempY = myTransform.position.y;

        if(Anchored)
        {
            rb.gravityScale = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        currentmagnitude = rb.linearVelocity.magnitude;

        if (!outline)
        {
            OutlineObj.SetActive(false);
        }
        else OutlineObj.SetActive(true);
        


    }

    public void Reset()
    {
        transform.position = new Vector3 (TempX, TempY, 0f);
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
        Anchored = true;
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
