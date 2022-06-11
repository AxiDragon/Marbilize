using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletGameobject;
    Bullet firedBullet;
    Rigidbody rb;

    void Start()
    {
        firedBullet = bulletGameobject.GetComponent<Bullet>();
        rb = transform.root.GetComponentInChildren<Rigidbody>();
    }

    public void ShootBullet()
    {
        Vector3 firingDirection = Quaternion.AngleAxis(Random.Range(-firedBullet.bullet.spread, firedBullet.bullet.speed), transform.up)
            * transform.forward;

        GameObject shot = Instantiate(bulletGameobject, transform.position + firingDirection, Quaternion.identity);
        shot.GetComponent<Rigidbody>().AddForce(firingDirection * firedBullet.bullet.speed, ForceMode.Impulse);
        rb.AddForce(-firingDirection * firedBullet.bullet.recoil, ForceMode.Impulse);
    }
}
