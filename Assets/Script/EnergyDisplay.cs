using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    public EnergyManager em;
    public Canvas cV;
    public Image ei;
    private float maxEnergy;

    public float dCD;

    void Start()
    {
        em = FindFirstObjectByType<EnergyManager>();
        maxEnergy = em.Energy;
    }

    // Update is called once per frame
    void Update()
    {
        ei.fillAmount = em.Energy / maxEnergy;

        if (em.Energy != maxEnergy)
        {
            dCD = 1f;
        }

        dCD -= Time.deltaTime;

        if (dCD > 0f)
        {
            cV.enabled = true;
        }
        else { cV.enabled = false; }

        if (dCD < 0f) { dCD = 0f; }

    }
}
