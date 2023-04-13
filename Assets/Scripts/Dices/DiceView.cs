using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private Button _removeButton;
    [SerializeField] private GameObject _dicePlaceHolder;
    
    private Dice _dice;
    private Dice _diceForUI;

    private void OnEnable() {
        _removeButton.onClick.AddListener(RemoveDice);
    }

    private void OnDisable() {
        _removeButton.onClick.RemoveListener(RemoveDice);
    }

    private void FixedUpdate() {
        if (_diceForUI) {
            _diceForUI.transform.localRotation = _dice.transform.rotation;
            //_diceForUI.transform.Rotate(0, 90, 0);
        }
    }

    private void RemoveDice() {
        DiceManager.Instance.RemoveDice(_dice);
    }

    public void Render(Dice dice) {
        _dice = dice;

        _label.text = dice.gameObject.name;
        _diceForUI = Instantiate(_dice, _dicePlaceHolder.transform);
        Rigidbody rigidbody1 = _diceForUI.GetComponent<Rigidbody>();
        rigidbody1.isKinematic = true;
        _diceForUI.transform.position = _dicePlaceHolder.transform.position;
        dice.SetDiceForUI(_diceForUI);
        _diceForUI.RemoveCamera();
        Destroy(_diceForUI.GetComponent<MouseAtractor>());
        // UI layer number 5
        // _diceForUI.gameObject.layer = 5;
        Transform[] transform1 = _diceForUI.GetComponentsInChildren<Transform>();
        foreach(Transform t in transform1) {
            t.gameObject.layer = 5;
        }
    }

    public void DiceViewSelected() {
        InputManager.Instance.SelectDice(_dice);
    }
}
