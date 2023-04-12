using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceSelectedCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _itemConteiner;
    [SerializeField] private DiceView _diceViewTemplate;
    //[SerializeField] private Button _backButton;

    private List<Dice> _diceList;

    private void Start() {
        _diceList = DiceManager.Instance.GetDiceList();
        DiceManager.Instance.OnDiceListChanged += DiceManager_OnDiceListChanged;
        Refresh();
    }

    private void DiceManager_OnDiceListChanged(object sender, System.EventArgs e) {
        Refresh();
    }

    private void Refresh() {
        foreach (Transform child in _itemConteiner.transform) {
            Destroy(child.gameObject);
        }
        foreach (Dice dice in _diceList) {
            AddItem(dice);
        }
    }

    private void AddItem(Dice dice) {
        DiceView diceView = Instantiate(_diceViewTemplate, _itemConteiner.transform);
        diceView.Render(dice);
    }
}
