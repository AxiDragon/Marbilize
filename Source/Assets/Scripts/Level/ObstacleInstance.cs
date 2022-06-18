using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstance : MonoBehaviour
{
    Obstacle obs;
    public Obstacle tokenObstacle;
    Rigidbody rb;
    public GameObject token, explosion;
    public bool tutorialBox;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (tutorialBox)
        {
            AssignObstacleStats(tokenObstacle);
        }
    }

    private void Update()
    {
        if (rb.velocity.magnitude > obs.breakThreshold)
            Explode();
    }

    public void Explode()
    {
        if (obs.tokenBox)
            Instantiate(token, transform.position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(transform.root.gameObject);
    }

    public void AssignObstacleStats(Obstacle stats)
    {
        obs = stats;
        if (obs.tokenBox)
            name = "TokenBox";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && rb.gameObject.layer == 11)
            rb.gameObject.layer = 3;
    }
}
