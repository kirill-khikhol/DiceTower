using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain:MonoBehaviour {
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _diceSelectedCanvas;

    private void Awake() {
        ToggleToMain();
    }

    private void ToggleToDiceSelected() {
        _mainCanvas.gameObject.SetActive(false);
        _diceSelectedCanvas.gameObject.SetActive(true);
    }

    private void ToggleToMain() {
        _mainCanvas.gameObject.SetActive(true);
        _diceSelectedCanvas.gameObject.SetActive(false);
    }

    private void Start() {
        InputManager.Instance.OnDiceSelected += InputManager_OnDiceSelected;
        InputManager.Instance.OnDiceUnselected += InputManager_OnDiceUnselected;
    }

    private void InputManager_OnDiceUnselected(object sender, System.EventArgs e) {
        ToggleToMain();
    }

    private void InputManager_OnDiceSelected(object sender, InputManager.OnDiceSelectedEventArgs e) {
        ToggleToDiceSelected();
        Debug.Log($"InputManager_OnDiceSelected {e.SelectedDice.gameObject.name}");
    }
}
