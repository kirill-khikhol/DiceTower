using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Dice:MonoBehaviour {

    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _activeColor;
    [SerializeField] private LayerMask _floorLayerMask;
    [SerializeField] private List<DiceSurfaceBase> _surfaces;
    [SerializeField] private float _forse = 5f;
    [SerializeField] private CinemachineVirtualCamera _diceVirtualCamera;

    public event EventHandler OnScoreCounted;

    private Rigidbody _rigidbody;
    private int _topSurfaceIndex = -1;
    private bool _isOnFloor = false;
    private bool _isCounted = false;
    private bool _isFirstUpdate = true;

    public int Score;
    private Dice _diceForUI;

    public CinemachineVirtualCamera DiceVirtualCamera { get => _diceVirtualCamera;}

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        foreach (DiceSurfaceBase surface in _surfaces) {
            surface.DeactivateSurface(_baseColor);
        }
    }

    private void FixedUpdate() {
        if (_isOnFloor && !_isCounted && _rigidbody.velocity == Vector3.zero) {
            CountDice();
        }
        //check if dice is stuck
        if (_isFirstUpdate) {
            _isFirstUpdate = false;
        } else if (!_isOnFloor && _rigidbody.velocity == Vector3.zero) {
            Unstuck();
        }
    }

    private void CountDice() {
        float top = float.MinValue;
        for(int i=0; i< _surfaces.Count;i++) {
            float y = _surfaces[i].transform.position.y;
            if (y >= top) {
                top = y;
                _topSurfaceIndex = i;
            }
        }
        Score = _surfaces[_topSurfaceIndex].Score;
        ActivateDiceSurface(_topSurfaceIndex);
        _isOnFloor = true;
        _isCounted = true;
        OnScoreCounted?.Invoke(this, EventArgs.Empty);
    }
    private void PickUp() {
        if (_topSurfaceIndex>-1) {
            DeactivateDiceSurface(_topSurfaceIndex);
        }
        _topSurfaceIndex = -1;
        _isOnFloor = false;
        _isCounted = false;
        Score = 0;
    }

    private void OnCollisionEnter(Collision collision) {
        if (_floorLayerMask.value == 1 << collision.gameObject.layer) {
            _isOnFloor = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (_floorLayerMask.value == 1 << collision.gameObject.layer) {
            PickUp();
        }
    }

    private void Unstuck() {
        Vector3 dir = UnityEngine.Random.insideUnitCircle.normalized;
        _rigidbody.AddForce(dir * _forse, ForceMode.Impulse);
    }

    public void ActivateDiceSurface(int surfaceIndex) {
        _surfaces[surfaceIndex].ActivateSurface(_activeColor);
        if (_diceForUI) {
            _diceForUI.ActivateDiceSurface(surfaceIndex);
        }
    }
    public void DeactivateDiceSurface(int surfaceIndex) {
        _surfaces[surfaceIndex].DeactivateSurface(_baseColor);
        if (_diceForUI) {
            _diceForUI.DeactivateDiceSurface(surfaceIndex);
        }
    }
    public void SetDiceForUI(Dice dice) {
        _diceForUI= dice;
    }

    public void RemoveCamera() {
        if (!_diceForUI) {
            Destroy(_diceVirtualCamera.gameObject);
        }
    }
}
