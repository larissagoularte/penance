using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour { 

    public float mouseSensitivity = 500;
    public Transform playerBody;
    private float xRotation = 0;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;                                               // Avoids the cursos going off game screen
    }

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;            // Using deltaTime prevents the rotation velocity changing depending on frame rate
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                          // Simulates the actual vertical movement of a human head, 90 degrees up and 90 degrees down
        playerBody.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
