using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    /////////////////////////////////////////////////

    public ObjectPull[] objects;

    /////////////////////////////////////////////////

    public Animator anim;
    public CinemachineFollow cam;
    public TransitionScript tr;
    
    /////////////////////////////////////////////////

    public PlayerMovementPlatformer pmp;

    public Transform maaike;
    public Transform cp;

    /////////////////////////////////////////////////

    public int hp;
    public int hpMax;

    /////////////////////////////////////////////////

    void Start()
    {
        pmp = FindFirstObjectByType<PlayerMovementPlatformer>();
        maaike = FindFirstObjectByType<PlayerMovementPlatformer>().transform;
        tr = FindFirstObjectByType<TransitionScript>();
        cam = FindFirstObjectByType<CinemachineFollow>();
        ChangeHP(hpMax);

        objects = FindObjectsByType<ObjectPull>(FindObjectsSortMode.None);

    }
    public void ChangeHP(int newAmount)
    {
        hp = newAmount;
        if (hp <= 0)
        {
            pmp.enabled = false;
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
            foreach (ObjectPull obj in objects)
            { 
                obj.Reset();
            }
            StartCoroutine(DeathTransition());
        }
    }

    private IEnumerator DeathTransition()
    {
        StartCoroutine(tr.TransitionEnterTimer());
        yield return new WaitForSeconds(1.7f);
        print("adada");
        cam.FollowOffset.z = 0;
        transform.position = cp.position;
        //yield return new WaitForSeconds(0.5f);
        cam.FollowOffset.z = -10;
        hp = hpMax;
        pmp.enabled=true;
        StartCoroutine(tr.TransitionExitTimer());
    }



    void Update()
    {
    }
}
