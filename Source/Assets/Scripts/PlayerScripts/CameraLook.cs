using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 100f;
    float xRotation = 0f;

    Transform playerBody;

    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveCamera(InputAction.CallbackContext callback)
    {
        Vector2 rotation = callback.ReadValue<Vector2>() * sensitivity;

        xRotation -= rotation.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerBody.Rotate(Vector3.up * rotation.x);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
