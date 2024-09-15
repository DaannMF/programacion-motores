using System;
using UnityEngine;

public class Rotate : MonoBehaviour {
    private readonly float degrees = .5f;
    private Rigidbody2D rigidBody;

    private void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        RotateObstacle();
    }

    private void RotateObstacle() {
        float velocity = degrees * Time.deltaTime;
        this.rigidBody.AddTorque(velocity, ForceMode2D.Force);
    }
}
