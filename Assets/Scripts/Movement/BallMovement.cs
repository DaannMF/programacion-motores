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

    private void Update() {
        if (!GameManager.Instance.GetIsPlaying()) {
            if (Input.GetKeyDown(keyLaunchBall)) {
                Launch();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (GameManager.Instance.IsPlayerGoalTag(other.gameObject.tag)) {
            GameManager.Instance.PlayerScored(other.gameObject.tag);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (GameManager.Instance.IsPlayerTag(other.gameObject.tag)) {
            GameManager.Instance.SetCurrentPlayer(other.gameObject);
            ForcePower power = other.gameObject.GetComponent<ForcePower>();
            this.rigidBody.velocity *= power.GetForce();
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
