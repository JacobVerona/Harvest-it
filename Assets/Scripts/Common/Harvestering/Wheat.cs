using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Wheat : MonoBehaviour
{
    public System.Action<Harvester> Harvesting;

    private void OnTriggerEnter (Collider other)
    {
        if (other.TryGetComponent(out Harvester harvester))
        {
            Harvesting?.Invoke(harvester);
        }
    }
}