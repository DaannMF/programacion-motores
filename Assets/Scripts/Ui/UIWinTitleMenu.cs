using UnityEngine;
using TMPro;
using System;

public class UIWinTitleMenu : MonoBehaviour {
    [SerializeField] private TMP_Text winTitle;

    private void OnEnable() {
        String winner = GameManager.Instance.GetWinner();
        this.winTitle.text = $"{winner.ToUpper()} Wins.";
    }
}
