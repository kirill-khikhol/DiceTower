using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsUI : MonoBehaviour
{
    [SerializeField] private Button _rollButton;

    public event EventHandler OnThrowToTower;

    private void Awake() {
        //_rollButton.onClick.AddListener(() => {
        //    OnThrowToTower?.Invoke(this, EventArgs.Empty);
        //});
    }
}
