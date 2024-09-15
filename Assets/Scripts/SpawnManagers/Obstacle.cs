using UnityEngine;

public class Obstacle : MonoBehaviour {
    [SerializeField] private float timeToLive = 7.0f;
    private float totalTime;

    private void OnEnable() {
        totalTime = 0;
    }

    private void Update() {
        DeActivate();
    }

    private void DeActivate() {
        this.totalTime += Time.deltaTime;
        if (this.totalTime > this.timeToLive) {
            gameObject.SetActive(false);
        }
    }
}
