using System;
using UnityEngine;

enum Power {
    Shield,
    Grown,
    Force
}

public class PowerUpManager : MonoBehaviour {
    private Power powerUp;
    private static PowerUpManager instance;
    public static PowerUpManager SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<PowerUpManager>();
            }
            return instance;
        }
    }

    public void ResetPowerUps() {
        GameObject[] players = GameManager.Instance.GetPlayers();

        foreach (GameObject player in players) {
            foreach (Power power in Enum.GetValues(typeof(Power))) {
                switch (power) {
                    case Power.Shield:
                        player.GetComponent<ShieldPower>().ResetPowerUp();
                        break;
                    case Power.Grown:
                        player.GetComponent<GrownPower>().ResetPowerUp();
                        break;
                    case Power.Force:
                        player.GetComponent<ForcePower>().ResetPowerUp();
                        break;
                }
            }
        }
    }
}
