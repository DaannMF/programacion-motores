using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour {
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button exitButton;

    [Header("Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject winTitle;


    private void Awake() {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        closeButton.onClick.AddListener(OnPlayButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void Update() {
        Pause();
    }

    private void OnDestroy() {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        closeButton.onClick.RemoveListener(OnPlayButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        creditsButton.onClick.RemoveListener(OnCreditsButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void Pause() {
        if (!winTitle.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                Time.timeScale = 0;
                if (!pausePanel.activeSelf) {
                    pausePanel.SetActive(true);
                    scorePanel.SetActive(false);
                }
            }
        }
    }

    private void OnPlayButtonClicked() {
        pausePanel.SetActive(false);
        scorePanel.SetActive(true);
        Time.timeScale = 1;
    }

    private void OnSettingsButtonClicked() {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    private void OnCreditsButtonClicked() {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private void OnExitButtonClicked() {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }
}
