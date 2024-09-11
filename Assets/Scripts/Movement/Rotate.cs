using System;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private readonly Int16 degrees = 1;
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


    private void OnTriggerEnter2D(Collider2D other) {

    }

    private void RotatePlayer() {
        // Rotate Left
        if (Input.GetKey(keyRotationLeft)) {
            this.rigidBody.AddTorque(degrees);
        }

        // Rotate Right
        if (Input.GetKey(keyRotationRight)) {
            this.rigidBody.AddTorque(-degrees);
        }
    }
}
