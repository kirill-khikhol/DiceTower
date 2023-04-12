using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _mainVirtualCamera;

    private CinemachineVirtualCamera _currentVirtualCamera;

    private const int _activeValue = 11;
    private const int _inactiveValue = 10;

 public static CameraManager Instance { get; private set; }

    private void Awake() {
        Instance = this;
        _currentVirtualCamera = _mainVirtualCamera;
        _currentVirtualCamera.Priority = _activeValue;
    }

    private void Start() {
        InputManager.Instance.OnDiceSelected += InputManager_OnDiceSelected;
        InputManager.Instance.OnDiceUnselected += InputManager_OnDiceUnselected;
    }

    private void InputManager_OnDiceUnselected(object sender, System.EventArgs e) {
        ChangeToMainCamera();
    }

    private void InputManager_OnDiceSelected(object sender, InputManager.OnDiceSelectedEventArgs e) {
        ChangeToDiceCamera(e.SelectedDice);
    }

    private void ChangeToDiceCamera(Dice dice) {
        ChangeToCamera(dice.DiceVirtualCamera);
    }

    private void ChangeToMainCamera() {
        ChangeToCamera(_mainVirtualCamera);
    }

    private void ChangeToCamera(CinemachineVirtualCamera camera) {
        _currentVirtualCamera.Priority = _inactiveValue;
        _currentVirtualCamera = camera;
        _currentVirtualCamera.Priority = _activeValue;
    }
}
