using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseAtractor : MonoBehaviour
{
    private Vector3 _mousePosition;
    private Rigidbody _rigidbody;
    private float _stopRange = 1f;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Log(_rigidbody);
    }

    void FixedUpdate() {
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit)) {
                _mousePosition = raycastHit.point;
            }
                Debug.Log(_mousePosition);
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
