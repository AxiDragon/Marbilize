using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ScriptableBullet bulletStats;
    public GameObject explosion;
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
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

            if (!bulletStats.affectsPlayer && rb.CompareTag("Player"))
                continue;

            if (rb.gameObject.layer == 11)
                rb.gameObject.layer = 3;

            if (rb.name.Contains("Token") && rb.TryGetComponent(out ObstacleInstance obstacle))
               obstacle.Explode();

            rb.AddExplosionForce(bulletStats.explosionForce, transform.position, bulletStats.explosionWidth);
        }
        
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(transform.root.gameObject);
    }

    public void AssignStats(ScriptableBullet attachment) => bulletStats = attachment;
}
