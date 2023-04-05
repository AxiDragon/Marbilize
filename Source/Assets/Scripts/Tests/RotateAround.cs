using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float rotationSpeed = 2f;
    
    void Update()
    {
        transform.RotateAround(target.position, Vector3.up,  Time.deltaTime * rotationSpeed);
    }
}
