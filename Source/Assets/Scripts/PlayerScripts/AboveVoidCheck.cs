using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveVoidCheck : MonoBehaviour
{
    public static bool isInside = true;

    private void OnTriggerStay(Collider other)
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
