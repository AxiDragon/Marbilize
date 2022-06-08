using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    float radiusMult = 25f;
    float explosionForceMult = 500f;
    float radius, explosionForce;

    void Start()
    {
        radius = GetComponent<Collider>().bounds.size.magnitude * radiusMult;
        explosionForce = GetComponent<Collider>().bounds.size.magnitude * explosionForceMult;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player")
            Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius);
            }
        }
        Destroy(transform.root.gameObject);
    }
}
