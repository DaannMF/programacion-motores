using UnityEngine;

public class Movement : MonoBehaviour {

    [Header("Handles the movement logic")]
    const float MAX_SPEED = 1f;
    const float MIN_SPEED = 1f;
    private float speed = 0.01F;
    [SerializeField] private KeyCode keyUp = KeyCode.W;
    [SerializeField] private KeyCode keyDown = KeyCode.S;
    [SerializeField] private KeyCode keyRigth = KeyCode.D;
    [SerializeField] private KeyCode keyLeft = KeyCode.A;

    // Update is called once per frame
    void Update() {

        Vector3 pos = transform.position;

        // Up
        if (Input.GetKey(keyUp)) {
            pos.y += speed;
        }

        // Down
        if (Input.GetKey(keyDown)) {
            pos.y -= speed;
        }

        // Left
        if (Input.GetKey(keyLeft)) {
            pos.x -= speed;
        }

        // Rigth
        if (Input.GetKey(keyRigth)) {
            pos.x += speed;
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
