using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class DoorOpening : MonoBehaviour
{
    public Animator anim;

    public Telekinesis tk;
    public int requiredDead;
    private List<EnemyHealth> _ennemiesToOpen;

    public void Start()
    {
        tk = FindFirstObjectByType<Telekinesis>();
    }

    public void Add(EnemyHealth enemy)
    {
        if(_ennemiesToOpen == null)
        {
            _ennemiesToOpen = new List<EnemyHealth>();
        }

        _ennemiesToOpen.Add(enemy);
    }

    public void TryOpen(EnemyHealth enemyToOpen)
    {
        _ennemiesToOpen.Remove(enemyToOpen);
        if(_ennemiesToOpen.Count<=0)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        anim.SetTrigger("Open");
    }
    


}
