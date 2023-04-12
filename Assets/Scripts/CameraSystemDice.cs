using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystemDice : MonoBehaviour
{
    [SerializeField] private  float _rotateSpeed = 20;

    private void Update() {
        float rotateDir = 1f;

        transform.eulerAngles += new Vector3(0f, rotateDir * _rotateSpeed * Time.deltaTime, 0f);
    }
}
