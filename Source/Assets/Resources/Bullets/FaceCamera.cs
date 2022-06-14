using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    GameObject mainCamera;
    public bool flip = false;
    public bool full;
    public Vector3 adjustment;
    float flipped = 0f;

    private void Start()
    {
        mainCamera = GameObject.Find("POVCamera");
        if (flip)
            flipped = 180f;
    }

    void Update()
    {
        Vector3 camRot = mainCamera.transform.eulerAngles;
        if (full)
            transform.eulerAngles = new Vector3 (camRot.x + 90f + flipped, camRot.y, camRot.z + 180f + flipped) + adjustment;
        else
            transform.eulerAngles = new Vector3(90f + flipped, camRot.y, 180f + flipped) + adjustment;
    }
}