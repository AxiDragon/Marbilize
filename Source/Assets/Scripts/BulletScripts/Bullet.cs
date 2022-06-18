using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ScriptableBullet bulletStats;
    public GameObject explosion;
    bool sniper;
    bool bomb;
    Vector3 force;

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player") && !bomb)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bulletStats.explosionWidth * ItemStats.explosionWidthMod);

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

            rb.AddExplosionForce(bulletStats.explosionForce * ItemStats.explosionPowerMod, transform.position, bulletStats.explosionWidth);
        }

        if (bulletStats.explode)
            Instantiate(explosion, transform.position, Quaternion.identity);

        if (!sniper)
            Destroy(transform.root.gameObject);
        else
            GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public void AssignStats(ScriptableBullet attachment)
    {
        bulletStats = attachment;

        if (bulletStats.name.Contains("Snipe"))
        {
            sniper = true;
            StartCoroutine(PierceTimer());
        }

        if (bulletStats.name.Contains("Bomb"))
        {
            bomb = true;
            StartCoroutine(BombTimer());
        }
    }
    public void AssignStats(ScriptableBullet attachment, Vector3 fireForce)
    {
        force = fireForce;
        bulletStats = attachment;

        if (bulletStats.name.Contains("Snipe"))
        {
            sniper = true;
            StartCoroutine(PierceTimer());
        }

        if (bulletStats.name.Contains("Bomb"))
        {
            bomb = true;
            StartCoroutine(BombTimer());
        }
    }
    IEnumerator PierceTimer()
    {
        float timer = 0f;

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(transform.root.gameObject);
    }

    IEnumerator BombTimer()
    {
        float timer = 0f;

        while (timer < .5f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Explode();
    }
}
