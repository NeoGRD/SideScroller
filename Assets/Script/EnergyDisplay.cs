using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    public EnergyManager em;
    public Image ei;
    private float maxEnergy;

    void Start()
    {
        em = FindFirstObjectByType<EnergyManager>();
        maxEnergy = em.Energy;
    }

    // Update is called once per frame
    void Update()
    {
        ei.fillAmount = em.Energy / maxEnergy;
    }
}
