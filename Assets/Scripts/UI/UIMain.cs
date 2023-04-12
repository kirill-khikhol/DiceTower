using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain:MonoBehaviour {
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _diceSelectedCanvas;

    private void Awake() {
        //FIXME: Uncomment me
        //_mainCanvas.gameObject.SetActive(true);
        //_diceSelectedCanvas.gameObject.SetActive(false);

        {//FIXME: remove me
            _mainCanvas.gameObject.SetActive(false);
            _diceSelectedCanvas.gameObject.SetActive(true);
        }
    }

    public void ToggleToDiceSelected() {
        _mainCanvas.gameObject.SetActive(false);
        _diceSelectedCanvas.gameObject.SetActive(true);
    }

    public void ToggleToMain() {
        _mainCanvas.gameObject.SetActive(true);
        _diceSelectedCanvas.gameObject.SetActive(false);
    }

    private void Start() {
        InputManager.Instance.OnDiceSelected += InputManager_OnDiceSelected;
    }

    private void InputManager_OnDiceSelected(object sender, InputManager.OnDiceSelectedEventArgs e) {
        _mainCanvas.gameObject.SetActive(false);
        _diceSelectedCanvas.gameObject.SetActive(true);
        Debug.Log($"InputManager_OnDiceSelected {e.SelectedDice.gameObject.name}");
    }
}
