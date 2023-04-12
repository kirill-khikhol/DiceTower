using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Button _removeButton;
    
    private Dice _dice;

    private void OnEnable() {
        _removeButton.onClick.AddListener(RemoveDice);
    }

    private void OnDisable() {
        _removeButton.onClick.RemoveListener(RemoveDice);
    }

    private void RemoveDice() {
        DiceManager.Instance.RemoveDice(_dice);
    }

    public void Render(Dice dice) {
        _dice = dice;
        _label.text = dice.gameObject.name;
    }
}
