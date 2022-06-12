using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinMove : MonoBehaviour
{
    Rigidbody playerRb;
    Vector3 startPos;
    public float reduction;
    public bool moveSideways;

    void Start()
    {
        playerRb = transform.root.GetComponentInChildren<Rigidbody>();
        startPos = transform.localPosition;
    }

    void Update()
    {
        Vector3 pos = startPos - CorrectVector(playerRb.velocity) / reduction;

        transform.localPosition = moveSideways ? pos : new Vector3(0f, pos.y, pos.x);
    }

    Vector3 CorrectVector(Vector3 v)
    {
        return new Vector3(Mathf.Abs(v.x), v.y, Mathf.Abs(v.z));
    }
}
