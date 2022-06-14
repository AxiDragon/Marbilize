using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveVoidCheck : MonoBehaviour
{
    Health health;
    LayerMask layerMask;
    public float punishment;

    private void Start()
    {
        health = FindObjectOfType<Health>();
        layerMask = GetComponent<PlayerMovement>().groundMask;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (!Physics.Raycast(ray, 1000f, layerMask) && health.health > 0f)
            health.DepleteHealth(punishment);
    }
}
