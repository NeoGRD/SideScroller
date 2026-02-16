using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovementPlatformer : MonoBehaviour
{
    /////////////////////////////////////////////////////////////

    public Animator anim;

    /////////////////////////////////////////////////////////////

    public SpriteRenderer sr;
    public Rigidbody2D rb; //Ne pas oublier d'activer la gravity scale du rigidbody et d'ajouter un collider
    public float speed = 1;
    public float jumpforce = 1;
    public LayerMask mask; //Quels layer seront affecté par le raycast attention a ne pas ajouter le layer de votre perso sinon le raycast va trouver le perso avant de trouver le sol

    /////////////////////////////////////////////////////////////

    private float wallJump;
    private float wjDirection = 0;
    public bool DoubleJump;

    /////////////////////////////////////////////////////////////

    public bool isOnGround;
    public float coyoteTimeCD;
    public bool coyoteTime;

    /////////////////////////////////////////////////////////////
    
    void Update()
    {

        if (rb.linearVelocityX > 0)
        {
             sr.flipX = true;
        }
        else if (rb.linearVelocityX < 0 || !isOnGround && CheckWallL())
        {
            sr.flipX = false;
        }

        /////////////////////////////////////////////////////////////

        var hDirection = 0f;
        var vDirection = 0f;
        isOnGround = CheckGround();

        /////////////////////////////////////////////////////////////

        if (coyoteTimeCD > 0 && coyoteTimeCD < 0.5f)
        { 
            coyoteTime = true; 
        }
        else coyoteTime = false;

        coyoteTimeCD -= Time.deltaTime * 2.5f;

        /////////////////////////////////////////////////////////////

            if (coyoteTimeCD < 0)
        {
            coyoteTimeCD = 0;
        }

            if (coyoteTimeCD > 0.65f)
        {
            coyoteTimeCD = 0.65f;
        }

        /////////////////////////////////////////////////////////////

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                vDirection += jumpforce;
            }
            else
            {
                if (CheckWallR())
                {
                    vDirection += jumpforce;
                    wjDirection = -1;
                    wallJump = 10f;
                }
                else if (CheckWallL())
                {
                    vDirection += jumpforce;
                    wjDirection = 1;
                    wallJump = 10f;
                }

                else if (DoubleJump == true)
                {
                    if (coyoteTime == true)
                    {
                        coyoteTimeCD = 0f;
                        DoubleJump = true;
                    }
                    else DoubleJump = false;

                    rb.linearVelocityY = 0;
                    vDirection += jumpforce;
                }
                
                if (coyoteTime == true)
                {
                    coyoteTimeCD = 0;
                }

            }
            
            coyoteTimeCD = 0;

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            hDirection += 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            hDirection += -1;
        }   

            wallJump = Mathf.Clamp(wallJump - Time.deltaTime * 10, 0, 10f);

        rb.linearVelocity = new Vector2(hDirection * speed+wallJump*wjDirection, rb.linearVelocityY+vDirection); //On set up la velocité horizontal 

        /////////////////////////////////////////////////////////////

        if (rb.linearVelocityX != 0 && isOnGround && CheckWallL() == false && CheckWallR() == false) 
        {
            anim.Play("run");
        }

        else if (rb.linearVelocityX <= 0.5 && isOnGround)
        {
            anim.Play("Idle");
        }

        else if (!isOnGround && CheckWallL() == true && CheckWallR() == false)
        {
            anim.Play("wallHug");
        }

        else if (!isOnGround && CheckWallR() == true && CheckWallL() == false)
        {
            sr.flipX = true;
            anim.Play("wallHugleft");
        }

        else if (rb.linearVelocityY > 0 && !isOnGround)
        {
            anim.Play("jump");
        }

        else if (rb.linearVelocityY < 0 && !isOnGround)
        {
            anim.Play("fall");
        }

        else
        {
            anim.Play("Idle");
        }

    }

    public bool CheckGround()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1f, mask);
        if (rayCastHit)
        {
            wallJump = 0f;
            DoubleJump = true;
            coyoteTimeCD = 0.65f;
            return true;
        }
        return false;
    }
    public bool CheckWallR()
    {
        var rayCastHitWallright = Physics2D.Raycast(transform.position, new Vector2(1, 0), 0.6f, mask);
        if (rayCastHitWallright)
        {
            DoubleJump = true;
            return true;
        }
        return false;
    }
    public bool CheckWallL()
    {
        var rayCastHitWallright = Physics2D.Raycast(transform.position, new Vector2(-1,0), 0.6f, mask);
        if (rayCastHitWallright)
        {
            DoubleJump = true;
            return true;
        }
        return false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.purple;
        Gizmos.DrawRay(transform.position, Vector3.down * 1f);
        Gizmos.DrawRay(transform.position, Vector3.left * 0.6f);
        Gizmos.DrawRay(transform.position, Vector3.right * 0.6f);
    }

}