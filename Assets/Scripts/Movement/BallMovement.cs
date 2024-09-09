using System;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private Rigidbody2D rigidBody;

    [SerializeField] private float speed = 1f;

    [Header("Map keys")]
    [SerializeField] private KeyCode keyLaunchBall = KeyCode.Space;

    private void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition() {
        transform.position = Vector2.zero;
    }
}
