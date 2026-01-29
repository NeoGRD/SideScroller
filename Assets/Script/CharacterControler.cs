using UnityEngine;

public class CharacterControler : MonoBehaviour
{

    Rigidbody2D rigidbody2D;

    public Transform MyTransform;
    public float Velocity = 3f;
    public float PlayerSpeed;
    public float JumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) PlayerSpeed = -Velocity;

        else if (Input.GetKey(KeyCode.RightArrow)) PlayerSpeed = Velocity;

        else PlayerSpeed = 0;

        rigidbody2D.linearVelocity = new Vector2 (PlayerSpeed, rigidbody2D.linearVelocityY);


        if (Input.GetKey(KeyCode.UpArrow)) PlayerSpeed = -Velocity;


    }
}
