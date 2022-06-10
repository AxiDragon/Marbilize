using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 offset;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    void Update()
    {
        transform.position = offset + player.position;
    }
}
