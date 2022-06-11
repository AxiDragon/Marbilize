using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinMove : MonoBehaviour
{
    Rigidbody playerRb;
    public float reduction;

    void Start() => playerRb = transform.root.GetComponentInChildren<Rigidbody>();

    void Update()
    {

        transform.localPosition = -CorrectVector(playerRb.velocity) / reduction;
    }

    Vector3 CorrectVector(Vector3 v)
    {
        return new Vector3(Mathf.Abs(v.x), v.y, Mathf.Abs(v.z));
    }
}
