using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private bool _isGrabMode = false;
    public static InputManager Instance { get; private set; }

    public event EventHandler OnGrab;
    public event EventHandler OnRelise;
    public event EventHandler OnRollDice;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if(_isGrabMode && Input.GetMouseButtonDown(1)) {
            OnGrab?.Invoke(this, EventArgs.Empty);
        }
        if(_isGrabMode && Input.GetMouseButtonUp(1)) {
            OnRelise?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RollDice() {
        OnRollDice?.Invoke(this, EventArgs.Empty);
    }

    public void ToggleGrabMode(Toggle toggle) {
        _isGrabMode = toggle.isOn;
    }
}
