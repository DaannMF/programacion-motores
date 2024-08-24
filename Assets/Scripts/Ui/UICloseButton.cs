using UnityEngine;
using UnityEngine.UI;

public class UICloseButton : MonoBehaviour {
    [SerializeField] private RectTransform parentRect;
    [SerializeField] private Button closeButton;

    private void Awake() {
        RectTransform rt = closeButton.GetComponent<RectTransform>();

        Vector3[] v = new Vector3[4];
        parentRect.GetWorldCorners(v);
        float offset = 25 / 2;
        float top = v[2].x - offset;
        float right = v[2].y - offset;
        rt.position = new Vector2(top, right);
    }
}
