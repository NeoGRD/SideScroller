using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    /////////////////////////////////////////////////

    public Animator anim;
    public CinemachineFollow cam;

    public Transform maaike;
    public Transform cp;

    /////////////////////////////////////////////////

    public int hp;
    public int hpMax;

    /////////////////////////////////////////////////

    void Start()
    {
        maaike = FindFirstObjectByType<PlayerMovementPlatformer>().transform;
        cam = FindFirstObjectByType<CinemachineFollow>();
        ChangeHP(hpMax);
    }
    public void ChangeHP(int newAmount)
    {
        hp = newAmount;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void AddHp(int newAmount)
    {
        ChangeHP(hp + newAmount);
    }

    public int GetHP()
    {
        return hp;
    }

    public void Die()
    {
        if (cp != null)
        {
            hp = hpMax;
            anim.Play("TransitionEnter");
            StartCoroutine(DeathTransition());
        }
    }

    private IEnumerator DeathTransition()
    {
        print("");
        cam.FollowOffset.z = 0;
        transform.position = cp.position;
        yield return new WaitForSeconds(0.5f);
        cam.FollowOffset.z = -10;
        anim.Play("TransitionExit");
    }



    void Update()
    {
    }
}
