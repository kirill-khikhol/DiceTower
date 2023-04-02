using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice:MonoBehaviour {
    private const int STOP_COUNT = 5;

    [SerializeField] private Rigidbody _rigidbody;
    private int _stopCount;
    private bool isCounted = false;


    private void FixedUpdate() {
        if (!isCounted && _rigidbody.velocity == Vector3.zero) {
            if (_stopCount < STOP_COUNT) {
                _stopCount++;
            } else {
                isCounted = true;
                Debug.Log("Count me");
            }
        }

      

    }
}
