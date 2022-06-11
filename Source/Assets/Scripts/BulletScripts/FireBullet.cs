using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletGameobject;
    Bullet firedBullet;
    Rigidbody rb;
    bool fired = false;
    float fireCooldown = .1f;

    void Start()
    {
        firedBullet = bulletGameobject.GetComponent<Bullet>();
        rb = transform.root.GetComponentInChildren<Rigidbody>();
    }

    public void ShootBullet(ScriptableBullet bullet)
    {
        if (!fired)
            return;

        StartCoroutine(Cooldown());

        Vector3 firingDirection = Quaternion.AngleAxis(Random.Range(-bullet.spread, 
            bullet.speed), transform.up)
            * transform.forward;

        Debug.DrawRay(transform.position, firingDirection * 5f, Color.red, 5f);

        GameObject shot = Instantiate(bulletGameobject, transform.position + firingDirection, Quaternion.identity);
        shot.GetComponent<Rigidbody>().AddForce(firingDirection * bullet.speed, ForceMode.Impulse);
        rb.AddForce(-firingDirection * bullet.recoil, ForceMode.Impulse);
    }

    IEnumerator Cooldown()
    {
        fired = true;
        yield return new WaitForSeconds(fireCooldown);
        fired = false;
    }
}
