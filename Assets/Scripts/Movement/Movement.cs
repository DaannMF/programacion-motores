using UnityEngine;

public class Movement : MonoBehaviour {
    const float MAX_SPEED = 6f;
    const float MIN_SPEED = 2.5f;
    private Rigidbody2D rigidBody;

    [SerializeField] private float speed = 2.5f;

    [Header("Map Keys")]
    [SerializeField] private KeyCode keyUp = KeyCode.W;
    [SerializeField] private KeyCode keyDown = KeyCode.S;

    private void Awake() {
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.SetMovementSeed(MIN_SPEED);
    }

    void Update() {
        Move();
    }

    private void Move() {
        float deltaSpeed = speed * Time.deltaTime * 1000;

        // Up
        if (Input.GetKey(keyUp)) {
            this.rigidBody.AddForce(Vector2.up * deltaSpeed);
        }

        // Down
        if (Input.GetKey(keyDown)) {
            this.rigidBody.AddForce(Vector2.down * deltaSpeed);
        }
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

    public void ResetPosition() {
        transform.position = new Vector2(transform.position.x, 0);
    }
}
