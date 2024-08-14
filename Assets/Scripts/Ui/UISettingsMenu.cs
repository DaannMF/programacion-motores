using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsMenu : MonoBehaviour {

    private Movement playerMovement1;
    private Movement playerMovement2;


    [Header("Players")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    [Header("Controls")]
    [SerializeField] private Slider slider1;
    [SerializeField] private Slider slider2;
    [SerializeField] private Button backButton;
    [SerializeField] private Button closeButton;


    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI textField1;
    [SerializeField] private TextMeshProUGUI textField2;

    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainPanel;

    private void Awake() {
        this.playerMovement1 = this.player1.GetComponent<Movement>();
        this.playerMovement2 = this.player2.GetComponent<Movement>();

        this.textField1.text = playerMovement1.GetMovementSeed().ToString("n2");
        this.textField2.text = playerMovement1.GetMovementSeed().ToString("n2");


        slider1.onValueChanged.AddListener(OnSliderValueChange1);
        slider2.onValueChanged.AddListener(OnSliderValueChange2);

        backButton.onClick.AddListener(OnBackButtonClicked);
        closeButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy() {
        slider1.onValueChanged.RemoveListener(OnSliderValueChange1);
        slider2.onValueChanged.RemoveListener(OnSliderValueChange2);

        backButton.onClick.RemoveListener(OnBackButtonClicked);
        closeButton.onClick.RemoveListener(OnBackButtonClicked);
    }

    public void OnSliderValueChange1(float value) {
        this.playerMovement1.SetMovementSeed(value);
        this.textField1.text = value.ToString("n2");
    }

    public void OnSliderValueChange2(float value) {
        this.playerMovement2.SetMovementSeed(value);
        this.textField2.text = value.ToString("n2");
    }

    private void OnBackButtonClicked() {
        this.settingsPanel.SetActive(false);
        this.mainPanel.SetActive(true);
    }
}
