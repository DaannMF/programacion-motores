using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField] private float timeToSpawnObstacles = 5.0f;
    [SerializeField] private float timeToSpawnPowerUp = 7.0f;

    [Header("Spawnable Area")]
    [SerializeField] private float left = -4.5f;
    [SerializeField] private float right = 4.5f;
    [SerializeField] private float bottom = -3f;
    [SerializeField] private float top = 3f;

    private void Start() {
        InvokeRepeating(nameof(SpawnObstacle), timeToSpawnObstacles, timeToSpawnObstacles);
        InvokeRepeating(nameof(SpawnPowerUp), timeToSpawnPowerUp, timeToSpawnPowerUp);
    }

    private void SpawnObstacle() {
        if (GameManager.Instance.GetIsPlaying()) {
            GameObject obstacle = ObstaclePool.SharedInstance.GetPooledObject();
            if (obstacle != null) {
                obstacle.transform.position = PeekObstacleRandomPoint();
                obstacle.SetActive(true);
            }
        }
    }

    private void SpawnPowerUp() {
        if (GameManager.Instance.GetIsPlaying()) {
            GameObject powerUp = PowerUpPool.SharedInstance.GetPooledObject();
            if (powerUp != null) {
                powerUp.transform.position = PeekPowerUpRandomPoint();
                powerUp.SetActive(true);
            }
        }
    }

    private Vector2 PeekObstacleRandomPoint() {
        float xPos = Random.Range(this.left, this.right);
        float yPos = Random.Range(this.bottom, this.top);
        return new Vector2(xPos, yPos);
    }

    private Vector2 PeekPowerUpRandomPoint() {
        float xPos = Random.Range(this.left, this.right);
        return new Vector2(xPos, this.top);
    }
}
