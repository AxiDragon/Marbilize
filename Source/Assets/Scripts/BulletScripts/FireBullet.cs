using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletGameobject;
    PlayerMovement movement;
    Rigidbody rb;
    [HideInInspector]
    public bool fired = false;
    float fireCooldown = .1f;

    void Start()
    {
        rb = transform.root.GetComponentInChildren<Rigidbody>();
        movement = rb.GetComponent<PlayerMovement>();
    }

    public void ShootBullet(ScriptableBullet bullet)
    {
        StartCoroutine(Cooldown());

        Vector3 firingDirection = Quaternion.AngleAxis(Random.Range(-bullet.spread, 
            bullet.speed), transform.up)
            * transform.forward;

        GameObject shot = Instantiate(bulletGameobject, transform.position + firingDirection, Quaternion.identity);
        
        Bullet bulletScript = shot.GetComponent<Bullet>();

        bulletScript.AssignStats(bullet, firingDirection * bullet.speed);

        shot.GetComponent<SphereCollider>().radius = bullet.collisionRadius;
        
        AudioSource audio = shot.GetComponent<AudioSource>();

        audio.clip = bullet.audio;
        audio.pitch = Random.Range(0.8f, 1.2f);

        if (bullet.name == "Shot (0)")
            audio.pitch *= 2f;

        if (bullet.isMelee)
        {
            audio.volume /= 1.2f;
            audio.Play();
            StartCoroutine(DelayExplosion(bulletScript));
        }
        
        audio.Play();
        
        shot.GetComponent<Rigidbody>().AddForce(firingDirection * bullet.speed, ForceMode.Impulse);

        Material mat = shot.GetComponentInChildren<MeshRenderer>().material;
        mat.SetTexture("_MainTex", bullet.bulletSprite.texture);
        mat.SetFloat("_Tier", bullet.tier);

        StartCoroutine(movement.Recoil(Vector3.Scale(-firingDirection * bullet.recoil, new Vector3(2f, .1f, 2f))));
    }

    IEnumerator Cooldown()
    {
        fired = true;
        yield return new WaitForSeconds(fireCooldown);
        fired = false;
    }

    IEnumerator DelayExplosion(Bullet bullet)
    {
        yield return new WaitForEndOfFrame();
        bullet.Explode();
    }
}
