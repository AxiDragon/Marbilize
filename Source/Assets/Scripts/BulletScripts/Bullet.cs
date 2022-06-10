using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ScriptableBullet bullet;
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player")
            Explode();
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bullet.explosionWidth);

        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(bullet.explosionForce, transform.position, bullet.explosionWidth);
            }
        }
        Destroy(transform.root.gameObject);
    }
}
