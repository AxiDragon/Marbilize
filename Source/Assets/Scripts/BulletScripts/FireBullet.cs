using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletGameobject;
    Bullet firedBullet;

    void Start()
    {
        firedBullet = bulletGameobject.GetComponent<Bullet>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 firingDirection = Quaternion.AngleAxis(Random.Range(-firedBullet.bullet.spread, firedBullet.bullet.speed), transform.up)
                * transform.forward;
            GameObject shot = Instantiate(bulletGameobject, transform.position + firingDirection, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(firingDirection * firedBullet.bullet.speed, ForceMode.Impulse);
        }
    }
}
