using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    [Header("Rotate player sprite")]
    private int degrees = 10;
    [SerializeField] private KeyCode keyRotationLeft = KeyCode.Q;
    [SerializeField] private KeyCode keyRotationRigth = KeyCode.E;

    // Update is called once per frame
    void Update() {

        // Rotate Left
        if (Input.GetKeyDown(keyRotationLeft)) {
            transform.Rotate(0, 0, degrees);
        }

        // Rotate Rigth
        if (Input.GetKeyDown(keyRotationRigth)) {
            transform.Rotate(0, 0, degrees * -1);
        }

    }
}
