using UnityEngine;

public class ForcePower : MonoBehaviour, IPowerUp {
    [SerializeField] private float normalStrength = 1.1f;
    [SerializeField] private float powerUpStrength = 1.4f;
    [SerializeField] private float ttl = 15.0f;

    private float force;

    public void ApplyPowerUp() {
        this.force = powerUpStrength;
        Invoke(nameof(ResetPowerUp), ttl);
    }

    public void ResetPowerUp() {
        this.force = normalStrength;
    }

    public float GetForce() {
        return force;
    }
}
