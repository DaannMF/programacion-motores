using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour {

    [Header("Handles the movement logic")]
    const float MAX_SPEED = 1f;
    const float MIN_SPEED = 0.1f;
    [SerializeField] private float speed = 0.01f;

    [SerializeField] private KeyCode keyUp = KeyCode.W;
    [SerializeField] private KeyCode keyDown = KeyCode.S;
    [SerializeField] private KeyCode keyRigth = KeyCode.D;
    [SerializeField] private KeyCode keyLeft = KeyCode.A;

    // Update is called once per frame
    void Update() {

        Vector3 pos = transform.position;
        float deltaSpeed = speed * Time.deltaTime * 1000;


        // Up
        if (Input.GetKey(keyUp)) {
            pos.y += deltaSpeed;
        }

        // Down
        if (Input.GetKey(keyDown)) {
            pos.y -= deltaSpeed;
        }

        // Left
        if (Input.GetKey(keyLeft)) {
            pos.x -= deltaSpeed;
        }

        // Rigth
        if (Input.GetKey(keyRigth)) {
            pos.x += deltaSpeed;
        }

        transform.position = pos;

    }

    public float GetMovementSeed() {
        return this.speed;
    }

    public void SetMovementSeed(float speed) {
        if (speed < MIN_SPEED) {
            this.speed = MIN_SPEED;
        }

        if (speed > MAX_SPEED) {
            this.speed = MAX_SPEED;
        }

        this.speed = speed;
    }
}
