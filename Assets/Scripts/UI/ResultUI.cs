using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ResultManager;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;

    private void Start() {
        ResultManager.Instance.OnResultChanged += ResultManager_OnResultChanged;
    }

    private void ResultManager_OnResultChanged(object sender, ResultManager.OnResultChangedEventArgs e) {
        _resultText.text = e.LastResult;
    }
}
