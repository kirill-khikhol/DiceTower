using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dice:MonoBehaviour {
    private const int STOP_COUNT = 5;

    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _activeColor;

    private Rigidbody _rigidbody;
    private TextMeshPro _topSurface;
    private int _stopCount;
    private bool _isReadyToCount = false;

    [SerializeField] private List<TextMeshPro> _surfaces;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log(_surfaces.Count);
        foreach(TextMeshPro surface in _surfaces) {
            surface.color= _baseColor;
        }
    }

    private void FixedUpdate() {
        if (!_isReadyToCount && _rigidbody.velocity == Vector3.zero) {
            if (_stopCount < STOP_COUNT) {
                _stopCount++;
            } else {
                _isReadyToCount = true;
                CountDice();
            }
        }
    }



    private void CountDice() {
        float top = float.MinValue;
        foreach (TextMeshPro surface in _surfaces) { 
            if(surface.transform.position.y >= top) {
                top = surface.transform.position.y;
                _topSurface = surface;
                
            }
        }
        Debug.Log($"top is {_topSurface.text}");
        _topSurface.color = _activeColor;

    }
    public void PickUp() {
        _topSurface.color = _baseColor;
        _isReadyToCount = false;
        _stopCount = 0;
        _topSurface = null;
    }
}
