using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Dice:MonoBehaviour {

    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _activeColor;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private List<TextMeshPro> _surfaces;
    [SerializeField] private float _forse = 50f;

    public event EventHandler OnScoreCounted;

    private Rigidbody _rigidbody;
    private TextMeshPro _topSurface;
    private bool _isOnFloor;
    private bool _isCounted;

    public string Score;


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log(_surfaces.Count);
        foreach (TextMeshPro surface in _surfaces) {
            surface.color = _baseColor;
        }
    }

    private void FixedUpdate() {
        if (_isOnFloor && !_isCounted && _rigidbody.velocity == Vector3.zero) {
            CountDice();
        }
        //check if dice is stuck
        if(!_isOnFloor && _rigidbody.velocity == Vector3.zero) {
            Unstuck();
        }
    }

    private void CountDice() {
        float top = float.MinValue;
        foreach (TextMeshPro surface in _surfaces) {
            if (surface.transform.position.y >= top) {
                top = surface.transform.position.y;
                _topSurface = surface;
            }
        }
        Score = _topSurface.text;
        _topSurface.color = _activeColor;
        _isOnFloor = true;
        _isCounted = true;
        OnScoreCounted?.Invoke(this, EventArgs.Empty);
    }
    private void PickUp() {
        if (_topSurface)
            _topSurface.color = _baseColor;
        _topSurface = null;
        _isOnFloor = false;
        _isCounted = false;
        Score = null;
    }

    private void OnCollisionEnter(Collision collision) {
        if (_layerMask.value == 1 << collision.gameObject.layer) {
            _isOnFloor = true;
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (_layerMask.value == 1 << collision.gameObject.layer) {
            PickUp();
        }
    }

    private void Unstuck() {
        Vector3 dir = UnityEngine.Random.insideUnitCircle.normalized;
        _rigidbody.AddForce(dir * _forse, ForceMode.Impulse);
    }

}
