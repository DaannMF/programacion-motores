using System;
using UnityEngine;

public class UICloseButton : MonoBehaviour {
    [SerializeField] private RectTransform parentRect;

    private void Update() {
        Vector3[] v = new Vector3[4];

        parentRect.GetLocalCorners(v);

        Debug.DrawLine(v[0], v[1], Color.red);
        Debug.DrawLine(v[1], v[2], Color.red);
        Debug.DrawLine(v[2], v[3], Color.red);
        Debug.DrawLine(v[3], v[0], Color.red);
    }
}
