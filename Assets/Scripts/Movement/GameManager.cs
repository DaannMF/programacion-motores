using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private BallMovement ball;
    [SerializeField] private Movement player1;

    [SerializeField] private Movement player2;


    void Start() {
        ReStart();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ReStart() {
        ball.ResetPosition();
        player1.ResetPosition();
        player2.ResetPosition();
    }
}
