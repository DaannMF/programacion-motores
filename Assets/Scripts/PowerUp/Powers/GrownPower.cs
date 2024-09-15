using UnityEngine;

public class GrownPower : MonoBehaviour, IPowerUp {
    [SerializeField] private float normalScale = 2.5f;
    [SerializeField] private float powerUpScale = 3.5f;
    [SerializeField] private float ttl = 15.0f;

    public void ApplyPowerUp() {
        Vector3 transform = this.transform.localScale;
        transform.y = this.powerUpScale;
        this.transform.localScale = transform;
        Invoke(nameof(ResetPowerUp), ttl);
    }

    public void ResetPowerUp() {
        Vector3 transform = this.transform.localScale;
        transform.y = this.normalScale;
        this.transform.localScale = transform;
    }
}
