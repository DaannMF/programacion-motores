using System;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private Boolean initialState = true;

    [SerializeField] private float speed = 1f;

    [Header("Map keys")]
    [SerializeField] private KeyCode keyLaunchBall = KeyCode.Space;

    private void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Launch();
    }

    private void Launch() {

    }

    public void Restart() {
        transform.position = Vector2.zero;
    }
}
