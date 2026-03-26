using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class Shooter : MonoBehaviour
{

    public int enemyType;
    public bool maaikeInRange;
    public float bulletSpeed = 5f;

    public BulletBehaviour Bullet;

    void Start()
    {
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
            newbullet.bulletSpeed = bulletSpeed;
            newbullet.Launch();
            yield return new WaitForSeconds(0.8f);
        }
    }

}

