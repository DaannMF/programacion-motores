using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour {

    const string BALL_TAG = "Ball";
    const string OBSTACLE_TAG = "Obstacle";
    const string P1_TAG = "Player1";
    const string P2_TAG = "Player2";
    const string P1_GOAL_TAG = "Player1Goal";
    const string P2_GOAL_TAG = "Player2Goal";
    const string PRESS_SPACE_MESSAGE = "Press space to Start";

    private Boolean isPLaying = false;
    private Int16 player1Score = 0;
    private Int16 player2Score = 0;
    private GameObject currentPlayer;

    [Header("Score Board")]
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;
    [SerializeField] private TMP_Text helperText;
    [SerializeField] private GameObject winTitlePanel;

    [Header("Entities")]
    [SerializeField] private BallMovement ball;
    [SerializeField] private Movement player1;
    [SerializeField] private Movement player2;

    [Header("Game Settings")]
    [SerializeField] private Int16 pointsToWin;

    private static GameManager instance;
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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ReStart();
        }
    }

    public void PlayerScored(String tag) {
        if (tag.Equals(P1_GOAL_TAG)) {
            Player1Scored();
        }
        else if (tag.Equals(P2_GOAL_TAG)) {
            Player2Scored();
        }

        if (this.player1Score >= this.pointsToWin || this.player2Score >= this.pointsToWin) {
            this.winTitlePanel.SetActive(true);
        }

        Reset();
    }

    private void Player1Scored() {
        player1Score++;
        player1ScoreText.text = this.player1Score.ToString();
    }

    private void Player2Scored() {
        player2Score++;
        player2ScoreText.text = this.player2Score.ToString();
    }

    public void ReStart() {
        this.player1Score = 0;
        this.player2Score = 0;
        player1ScoreText.text = player2Score.ToString();
        player2ScoreText.text = player2Score.ToString();
        this.winTitlePanel.SetActive(false);
        Reset();
    }

    public void Reset() {
        this.currentPlayer = null;
        helperText.text = PRESS_SPACE_MESSAGE;
        ball.ResetPosition();
        player1.ResetPosition();
        player2.ResetPosition();
        ObstaclePool.SharedInstance.DeactivateInstances();
        PowerUpPool.SharedInstance.DeactivateInstances();
        PowerUpManager.SharedInstance.ResetPowerUps();
        this.isPLaying = false;
    }

    public Boolean IsPlayerTag(String tag) {
        return tag.Equals(P1_TAG) || tag.Equals(P2_TAG);
    }

    public Boolean IsPlayerGoalTag(String tag) {
        return tag.Equals(P1_GOAL_TAG) || tag.Equals(P2_GOAL_TAG);
    }

    public Boolean IsBallTag(String tag) {
        return tag.Equals(BALL_TAG);
    }

    public Boolean IsObstacleTag(String tag) {
        return tag.Equals(OBSTACLE_TAG);
    }

    public Boolean GetIsPlaying() {
        return isPLaying;
    }

    public void SetIsPlaying(Boolean isPLaying) {
        this.isPLaying = isPLaying;
        this.helperText.text = String.Empty;
    }

    public GameObject GetCurrentPlayer() {
        return this.currentPlayer;
    }

    public GameObject[] GetPlayers() {
        return new[]{
            GameObject.FindGameObjectWithTag(P1_TAG),
            GameObject.FindGameObjectWithTag(P2_TAG)
        };
    }

    public String GetWinner() {
        if (this.player1Score >= this.pointsToWin) {
            return P1_TAG;
        }
        else {
            return P2_TAG;
        }
    }

    public void SetCurrentPlayer(GameObject player) {
        if (IsPlayerTag(player.tag)) {
            this.currentPlayer = player;
        }
    }
}
