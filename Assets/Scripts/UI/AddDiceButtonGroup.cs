using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddDiceButtonGroup : MonoBehaviour
{
    
    [SerializeField] private List<AddDiceButton> _addDiceButtonList = new();
    private List<Vector3> _initialPositionList = new();
    private bool _isShown;

    private void Awake() {
        GetComponent<Button>().onClick.AddListener(ToggleButtons);
        foreach(AddDiceButton button in _addDiceButtonList) {
            _initialPositionList.Add(button.transform.position);
            button.transform.position = transform.position;
            button.gameObject.SetActive(_isShown);
            button.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    private void ToggleButtons() {
        if(_isShown ) {
            HideButtons();
        } else {
            ShowButtons();
        }
    }

    private void ShowButtons() {
        int count = _addDiceButtonList.Count;
        float duration = 1f;
        _isShown = true;
        for( int i = 0;i < count; i++ ) {
            AddDiceButton addDiceButton = _addDiceButtonList[i];
            addDiceButton.gameObject.SetActive(_isShown);
            _addDiceButtonList[i].transform.DOMove(_initialPositionList[i], duration, false).OnComplete(() => {
                addDiceButton.gameObject.GetComponent<Button>().interactable = true;
            }); 
        }
    }

    private void HideButtons() {
        int count = _addDiceButtonList.Count;
        float duration = 1f;
        _isShown = false;
        for (int i = 0; i < count; i++) {
            AddDiceButton addDiceButton = _addDiceButtonList[i];
            addDiceButton.gameObject.GetComponent<Button>().interactable = false;
            addDiceButton.transform.DOMove(transform.position, duration, false).OnComplete(() => {
                addDiceButton.gameObject.SetActive(_isShown);
            });
        }
    }
}
