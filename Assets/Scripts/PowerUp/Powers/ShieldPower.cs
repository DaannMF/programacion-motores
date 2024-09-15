using UnityEngine;

public class ShieldPower : MonoBehaviour, IPowerUp {
    [SerializeField] private GameObject shield;
    [SerializeField] private float ttl = 15.0f;

    public void ApplyPowerUp() {
        this.shield.SetActive(true);
        Invoke(nameof(ResetPowerUp), ttl);

    }

    public void ResetPowerUp() {
        this.shield.SetActive(false);
    }
}
