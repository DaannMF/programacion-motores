using System;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour {
    const String SHIELD = "SHIELD";
    const String FORCE = "FORCE";
    const String GROWN = "GROWN";
    const String DEFAULT = "POWER UP";

    [SerializeField] private Power powerUp;
    private TMP_Text textMesh;

    private void Awake() {
        this.textMesh = GetComponent<TMP_Text>();
    }

    private void OnEnable() {
        PeekRandomPower();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        String tag = other.gameObject.tag;

        if (GameManager.Instance.IsBallTag(other.gameObject.tag)) {
            ApplyPowerUp();
        }

        if (!GameManager.Instance.IsObstacleTag(tag)) {
            this.gameObject.SetActive(false);
        }
    }

    private void PeekRandomPower() {
        Array values = Enum.GetValues(typeof(Power));
        System.Random random = new();
        Power power = (Power)values.GetValue(random.Next(values.Length));
        this.powerUp = power;

        switch (this.powerUp) {
            case Power.Shield:
                this.textMesh.text = SHIELD;
                break;
            case Power.Grown:
                this.textMesh.text = GROWN;
                break;
            case Power.Force:
                this.textMesh.text = FORCE;
                break;
            default:
                Debug.LogError("Power not implemented");
                this.textMesh.text = DEFAULT;
                break;
        }
    }

    private void ApplyPowerUp() {
        GameObject player = GameManager.Instance.GetCurrentPlayer();
        if (player == null) return;

        switch (this.powerUp) {
            case Power.Shield:
                player.GetComponent<ShieldPower>().ApplyPowerUp();
                break;
            case Power.Grown:
                player.GetComponent<GrownPower>().ApplyPowerUp();
                break;
            case Power.Force:
                player.GetComponent<ForcePower>().ApplyPowerUp();
                break;
            default:
                Debug.LogError("Power not implemented");
                return;
        }
    }
}
