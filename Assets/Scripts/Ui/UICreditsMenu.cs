using UnityEngine;
using UnityEngine.UI;

public class UICreditsMenu : MonoBehaviour {

    [Header("Buttons")]
    [SerializeField] private Button closeButton;

    [Header("Panels")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject creditsPanel;


    private void Awake() {
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnDestroy() {
        closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked() {
        creditsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
