using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static DiceManager;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;

    private void Start() {
        DiceManager.Instance.OnResultChanged += ResultManager_OnResultChanged;
    }

    private void ResultManager_OnResultChanged(object sender, DiceManager.OnResultChangedEventArgs e) {
        _resultText.text = e.LastResult;
    }
}
