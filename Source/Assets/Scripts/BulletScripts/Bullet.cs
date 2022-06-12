using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ScriptableBullet bulletStats;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player")
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bulletStats.explosionWidth);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb == null)
                continue;

            if (!bulletStats.affectsPlayer && rb.tag == "Player")
                continue;

            rb.AddExplosionForce(bulletStats.explosionForce, transform.position, bulletStats.explosionWidth);
        }

        Destroy(transform.root.gameObject);
    }

    public void AssignStats(ScriptableBullet attachment) => bulletStats = attachment;
}
