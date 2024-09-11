using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {


    const string P1_TAG = "Player1";
    const string P2_TAG = "Player2";
    const string P1_GOAL_TAG = "Player1Goal";
    const string P2_GOAL_TAG = "Player2Goal";
    const string PRESS_SPACE_MESSAGE = "Press space to Start";

    private static GameManager instance;

    private Boolean isPLaying = false;
    private Int16 player1Score = 0;
    private Int16 player2Score = 0;

    [Header("Score Board")]
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;
    [SerializeField] private TMP_Text helperText;

    [Header("Entities")]
    [SerializeField] private BallMovement ball;
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    // Singleton
    public static GameManager Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    void Start() {
        ReStart();
    }

    public void PlayerScored(String tag) {
        if (tag.Equals(P1_GOAL_TAG)) {
            Player1Scored();
        }
        else if (tag.Equals(P2_GOAL_TAG)) {
            Player2Scored();
        }

        ReStart();
    }

    private void Player1Scored() {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
    }

    private void Player2Scored() {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
    }

    public void ReStart() {
        helperText.text = PRESS_SPACE_MESSAGE;
        ball.ResetPosition();
        player1.ResetPosition();
        player2.ResetPosition();
        this.isPLaying = false;
    }

    public Boolean IsPlayerTag(String tag) {
        return tag.Equals(P1_GOAL_TAG) || tag.Equals(P2_GOAL_TAG);
    }

    public Boolean IsPlayerGoalTag(String tag) {
        return tag.Equals(P1_GOAL_TAG) || tag.Equals(P2_GOAL_TAG);
    }

    public Boolean GetIsPlaying() {
        return isPLaying;
    }

    public void SetIsPlaying(Boolean isPLaying) {
        this.isPLaying = isPLaying;
        this.helperText.text = String.Empty;
    }
}
