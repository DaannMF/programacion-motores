using UnityEngine;

public class ChangeColor : MonoBehaviour {

    [Header("Change the sprite color")]
    [SerializeField] private KeyCode keyChangeColor = KeyCode.C;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update() {
        ChangeRandomColor();
    }

    private void ChangeRandomColor() {
        if (Input.GetKeyUp(keyChangeColor)) {
            this.spriteRenderer.color = Random.ColorHSV();
        }
    }
}
