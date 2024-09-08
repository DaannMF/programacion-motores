using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private BallMovement ball;

    void Start() {
        ball.Restart();
    }

    // Update is called once per frame
    void Update() {

    }
}
