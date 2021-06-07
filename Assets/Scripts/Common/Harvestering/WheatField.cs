using UnityEngine;

public class WheatField : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Wheat _wheat;

    private void OnEnable ()
    {
        _wheat.Harvesting += Harvesting;
    }

    private void OnDisable ()
    {
        _wheat.Harvesting -= Harvesting;
    }

    public void Restore ()
    {
        _particles.gameObject.SetActive(false);
        _wheat.gameObject.SetActive(true);
    }

    private void Harvesting (Harvester harvester)
    {
        _particles.gameObject.SetActive(true);
        _wheat.gameObject.SetActive(false);
        harvester.Harvest(this);
    }
}
