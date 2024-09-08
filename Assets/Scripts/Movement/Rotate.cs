using System;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private readonly Int16 degrees = 10;
    private Rigidbody2D rigidBody;

    [Header("Map Keys")]
    [SerializeField] private KeyCode keyRotationLeft = KeyCode.Q;
    [SerializeField] private KeyCode keyRotationRight = KeyCode.E;

    private void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        RotatePlayer();
    }

    private void RotatePlayer() {
        // Rotate Left
        if (Input.GetKeyDown(keyRotationLeft)) {
            this.rigidBody.AddTorque(degrees);
        }

        // Rotate Right
        if (Input.GetKeyDown(keyRotationRight)) {
            this.rigidBody.AddTorque(-degrees);
        }
    }
}
