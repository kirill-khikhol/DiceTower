using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager:MonoBehaviour {
    [SerializeField] private LayerMask _mouseProjection;

    private bool _isGrabMode = false;
    //private Dice _selectedDice;
    public static InputManager Instance { get; private set; }

    public event EventHandler OnGrab;
    public event EventHandler OnRelise;
    public event EventHandler OnRollDice;
    public event EventHandler OnDiceUnselected;
    public event EventHandler<OnDiceSelectedEventArgs> OnDiceSelected;
    public class OnDiceSelectedEventArgs:EventArgs {
        public Dice SelectedDice { get; private set; }

        public OnDiceSelectedEventArgs(Dice selectedDice) {
            SelectedDice = selectedDice;
        }
    }

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (_isGrabMode && Input.GetMouseButtonDown(1) && !Helpers.IsOverUI()) {
            OnGrab?.Invoke(this, EventArgs.Empty);
        }
        if (_isGrabMode && Input.GetMouseButtonUp(1) && !Helpers.IsOverUI()) {
            OnRelise?.Invoke(this, EventArgs.Empty);
        }
        if (Input.GetMouseButtonUp(0) && !Helpers.IsOverUI()) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _mouseProjection)) {
                Dice selectedDice = raycastHit.collider.GetComponent<Dice>();
                if (selectedDice) {
                    OnDiceSelected?.Invoke(this, new OnDiceSelectedEventArgs(selectedDice));
                }
            } else {
                OnDiceUnselected?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void RollDice() {
        OnRollDice?.Invoke(this, EventArgs.Empty);
    }

    public void ToggleGrabMode(Toggle toggle) {
        _isGrabMode = toggle.isOn;
    }

    public void UnselectDice() {
        OnDiceUnselected?.Invoke(this, EventArgs.Empty);
    }
}
