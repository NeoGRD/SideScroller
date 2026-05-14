
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    /////////////////////////////////////////////////

    public ObjectPull op;
    public GameObject debris;
    public int SpawnDebris = 2;

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
                int debrisAmount = Random.Range(0, SpawnDebris + 1);
                float SPX = Random.Range(-0.5f, 0.5f);
                var posx = gameObject.transform.position.x;
                for (int i = 0; i < debrisAmount; i++)
                {
                    Instantiate(debris,new Vector3(posx += SPX, gameObject.transform.position.y, 0),gameObject.transform.rotation);
                }
                Destroy(attackObject.gameObject);
                Destroy(gameObject);

            }


        }
    }

    void Update()
    {
    }
}
