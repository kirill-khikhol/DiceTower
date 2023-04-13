using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseAtractor:MonoBehaviour {

    [SerializeField] private LayerMask _mouseProjection;

    private Vector3 _mousePosition;
    private Rigidbody _rigidbody;
    private float _stopRange = 3f;
    private bool _isGrabbed;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
        InputManager.Instance.OnGrab += InputManager_OnGrab;
        InputManager.Instance.OnRelise += InputManager_OnRelise;
        InputManager.Instance.OnRollDice += InputManager_OnThrowToTower;
    }
    private void OnDisable() {
        InputManager.Instance.OnGrab -= InputManager_OnGrab;
        InputManager.Instance.OnRelise -= InputManager_OnRelise;
        InputManager.Instance.OnRollDice -= InputManager_OnThrowToTower;
    }

    private void InputManager_OnThrowToTower(object sender, System.EventArgs e) {
        Debug.Log("InputManager_OnThrowToTower");
        float jumpPower = 100f;
        Vector3 position = DiceManager.Instance.ToweErntryPoint.position;
        _rigidbody.DOJump(position, jumpPower, 1, 1f, true);
        //Vector3 dir = Vector3.up;
        //_rigidbody.AddForce(dir * jumpPower, ForceMode.Impulse);
    }

    private void InputManager_OnRelise(object sender, System.EventArgs e) {
        Debug.Log("InputManager_OnRelise");
        _isGrabbed = false;
    }

    private void InputManager_OnGrab(object sender, System.EventArgs e) {
        Debug.Log("InputManager_OnRelise");
        _isGrabbed= true;
    }

    void FixedUpdate() {
        if (_isGrabbed) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _mouseProjection)) {
                _mousePosition = raycastHit.point;
            }
            Vector3 dir = _mousePosition - transform.position;
            if(dir.magnitude > _stopRange) { 
                float forse = 20f;
                _rigidbody.AddForce(dir*forse);

            } else {
                _rigidbody.velocity *= 0.8f;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_mousePosition, 0.3f);
    }
}
