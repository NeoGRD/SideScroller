using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class Shooter : MonoBehaviour
{

    public int enemyType;
    public bool maaikeInRange;
    public EnemyBehaviour eb;
    public BulletBehaviour Bullet;

    void Start()
    {
        //eb = FindFirstObjectByType<EnemyBehaviour>();
        StartCoroutine(shoot());
    }

    void Update()
    {

    }

    private IEnumerator shoot()
    {
        while (true)
        {
            var newbullet = Instantiate(Bullet);
            newbullet.transform.position = transform.position; 
            newbullet.transform.rotation = transform.rotation;
            newbullet.bulletSpeed = eb.bulletSpeed;
            newbullet.Launch();
            yield return new WaitForSeconds(eb.shootSpeed);
        }
    }

}

