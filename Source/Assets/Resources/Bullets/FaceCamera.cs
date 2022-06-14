using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    GameObject mainCamera;

    private void Start() => mainCamera = GameObject.Find("POVCamera");

    void Update()
    {
        Vector3 camRot = mainCamera.transform.eulerAngles;
        transform.eulerAngles = new Vector3 (camRot.x - 90f, camRot.y, camRot.z);
    }
}