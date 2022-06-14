using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveVoidCheck : MonoBehaviour
{
    Health health;
    public static bool isInside = true;

    private void Start()
    {
        health = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isInside = false;
    }
}
