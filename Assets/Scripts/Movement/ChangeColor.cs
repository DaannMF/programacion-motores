using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {
    [Header("Change the sprite color")]
    [SerializeField] private KeyCode keyChangeColor = KeyCode.C;

    SpriteRenderer spriteRenderer;

    private void Awake() {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (Input.GetKeyUp(keyChangeColor)) {
            this.spriteRenderer.color = Random.ColorHSV();
        }

    }
}
