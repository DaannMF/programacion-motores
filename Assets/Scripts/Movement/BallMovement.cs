using System;
using UnityEngine;

public class BallMovement : MonoBehaviour {



    private Rigidbody2D rigidBody;

    [SerializeField] private float speed = 40f;

    [Header("Map keys")]
    [SerializeField] private KeyCode keyLaunchBall = KeyCode.Space;

    private void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        ResetPosition();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        String tag = other.gameObject.tag;
        if (GameManager.Instance.IsPlayerGoalTag(tag)) {
            GameManager.Instance.PlayerScored(tag);
        }

        if (GameManager.Instance.IsPlayerTag(tag)) {
            this.speed++;
        }
    }

    private void Update() {
        if (!GameManager.Instance.GetIsPlaying()) {
            if (Input.GetKeyDown(keyLaunchBall)) {
                Launch();
            }
        }
    }

    private void Launch() {
        float deltaSpeed = speed * Time.deltaTime * 1000;

        int xVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
        int yVelocity = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;

        Vector2 force = new Vector2(xVelocity, yVelocity) * deltaSpeed;

        this.rigidBody.AddForce(force);
        GameManager.Instance.SetIsPlaying(true);
    }

    public void ResetPosition() {
        this.rigidBody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
