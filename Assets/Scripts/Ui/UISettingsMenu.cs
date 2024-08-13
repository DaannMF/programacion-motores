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

    [Header("TextFields")]
    [SerializeField] private TextMeshProUGUI textField1;
    [SerializeField] private TextMeshProUGUI textField2;

    [Header("Panels")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainPanel;

    private void Awake() {
        this.playerMovement1 = this.player1.GetComponent<Movement>();
        this.playerMovement2 = this.player2.GetComponent<Movement>();

        this.textField1.text = playerMovement1.GetMovementSeed().ToString();
        this.textField2.text = playerMovement1.GetMovementSeed().ToString();


        slider1.onValueChanged.AddListener(OnSliderValueChange1);
        slider2.onValueChanged.AddListener(OnSliderValueChange2);

        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy() {
        slider1.onValueChanged.RemoveListener(OnSliderValueChange1);
        slider2.onValueChanged.RemoveListener(OnSliderValueChange2);

        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    public void OnSliderValueChange1(float value) {
        this.playerMovement1.SetMovementSeed(value);
        this.textField1.text = value.ToString();
    }

    public void OnSliderValueChange2(float value) {
        this.playerMovement1.SetMovementSeed(value);
        this.textField2.text = value.ToString();
    }

    private void OnBackButtonClicked() {
        this.settingsPanel.SetActive(false);
        this.mainPanel.SetActive(true);
    }
}
