using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public event EventHandler OnGrab;
    public event EventHandler OnRelise;
    public event EventHandler OnThrowToTower;

    private void Awake() {
        Instance = this;
        //OnGrab?.ToString();
        //OnRelise?.ToString();
        //OnThrowToTower?.ToString();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            OnGrab?.Invoke(this, EventArgs.Empty);
        }
        if(Input.GetMouseButtonUp(0)) {
            OnRelise?.Invoke(this, EventArgs.Empty);
        }
        if(Input.GetMouseButtonDown(1)) {
            OnThrowToTower?.Invoke(this, EventArgs.Empty);
        }
    }


}
