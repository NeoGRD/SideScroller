
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    /////////////////////////////////////////////////

    public DoorOpening door;

    /////////////////////////////////////////////////

    public GameObject debris;
    public int SpawnDebris = 2;
    public int debrisMin = 0;

    /////////////////////////////////////////////////

    public int hp;
    public int hpMax;

    /////////////////////////////////////////////////

    void Start()
    {
        ChangeHP(hpMax);
        if(door != null)
        {
            door.Add(this);
        }
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
                int debrisAmount = Random.Range(debrisMin, SpawnDebris + 1);
                float SPX = Random.Range(-0.5f, 0.5f);
                var posx = gameObject.transform.position.x;
                for (int i = 0; i < debrisAmount; i++)
                {
                    Instantiate(debris,new Vector3(posx += SPX, gameObject.transform.position.y, 0),gameObject.transform.rotation);
                }
                attackObject.gameObject.SetActive(false);
                door.TryOpen(this);
                Destroy(gameObject);

            }


        }
    }

    void Update()
    {
    }
}
