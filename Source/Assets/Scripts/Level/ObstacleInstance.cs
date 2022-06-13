using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstance : MonoBehaviour
{
    Obstacle obs;
    Rigidbody rb;
    public GameObject token,explosion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > obs.breakThreshold)
            Explode();
    }

    private void Explode()
    {
        if (obs.tokenBox)
            Instantiate(token, transform.position, Quaternion.identity);
        
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(transform.root.gameObject);
    }

    public void AssignObstacleStats(Obstacle stats) => obs = stats;
}
