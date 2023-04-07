using UnityEngine;

public class CameraSystem : MonoBehaviour
{


    private void Update()
    {
        float rotateDir = 0f;
        //TODO extract to InputManager
        if (Input.GetKey(KeyCode.Q)) { rotateDir += 1f; }
        if (Input.GetKey(KeyCode.E)) { rotateDir -= 1f; }

        float rotateSpeed = 100f;

        transform.eulerAngles += new Vector3(0f, rotateDir*rotateSpeed*Time.deltaTime, 0f);
    }
}
