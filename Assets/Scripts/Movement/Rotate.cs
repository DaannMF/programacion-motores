using System;
using UnityEngine;

public class Rotate : MonoBehaviour {

    private readonly Int16 degrees = 10;

    [Header("Map Keys")]
    [SerializeField] private KeyCode keyRotationLeft = KeyCode.Q;
    [SerializeField] private KeyCode keyRotationRight = KeyCode.E;

    void Update() {
        RotatePlayer();
    }

    private void RotatePlayer() {
        // Rotate Left
        if (Input.GetKeyDown(keyRotationLeft)) {
            transform.Rotate(0, 0, degrees);
        }

        // Rotate Right
        if (Input.GetKeyDown(keyRotationRight)) {
            transform.Rotate(0, 0, -degrees);
        }
    }
}
