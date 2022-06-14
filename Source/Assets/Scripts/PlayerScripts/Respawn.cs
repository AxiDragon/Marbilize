using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    float threshold = -4f;
    public GameObject water;
    Timer timer;
    Transform respawnPoint;

    private void Start()
    {
        respawnPoint = GameObject.Find("StartPosition").transform;
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        if (transform.localPosition.y < threshold)
            RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
    }

    public void UpdateIncrement(float increment)
    {
        threshold += increment;
        water.transform.position += Vector3.up * increment;
    }

    public void UpdateRespawnPoint(Transform point)
    {
        respawnPoint = point;
    }
}
