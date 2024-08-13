using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour {
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;


    private void Awake() {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pausePanel.activeSelf) {
                pausePanel.SetActive(true);
            }
        }
    }

    private void OnDestroy() {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        creditsButton.onClick.RemoveListener(OnCreditsButtonClicked);
    }

    private void OnPlayButtonClicked() {
        pausePanel.SetActive(false);
    }

    private void OnSettingsButtonClicked() {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnCreditsButtonClicked() {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
