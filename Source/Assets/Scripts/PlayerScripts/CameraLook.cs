using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 100f;
    float xRotation = 0f;

    Transform playerBody;
    public GameObject head;
    Vector3 startRot;
    BulletInventoryUI ui;

    void Start()
    {
        startRot = head.transform.localEulerAngles;
        playerBody = transform.parent;
        ui = FindObjectOfType<BulletInventoryUI>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveCamera(InputAction.CallbackContext callback)
    {
        if (ui.paused || ui.choosingBullet)
            return;

        Vector2 rotation = callback.ReadValue<Vector2>() * sensitivity;

        xRotation -= rotation.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerBody.Rotate(Vector3.up * rotation.x);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        head.transform.localRotation = Quaternion.Euler(startRot.x + xRotation, startRot.y, startRot.z);
    }
}
