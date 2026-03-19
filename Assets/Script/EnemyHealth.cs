using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    /////////////////////////////////////////////////

    public ObjectPull op;


    /////////////////////////////////////////////////

    public int hp;
    public int hpMax;

    /////////////////////////////////////////////////

    void Start()
    {
        ChangeHP(hpMax);
    }
    public void ChangeHP(int newAmount)
    {
        hp = newAmount;
        if (hp <= 0)
        {
            Destroy(gameObject);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var attackObject = collision.gameObject.GetComponent<ObjectPull>();
        if (attackObject != null)
        {
            if (attackObject.CanHurt())
            {
                Destroy(attackObject.gameObject);
                Destroy(gameObject);

            }


        }
    }

    void Update()
    {
    }
}
