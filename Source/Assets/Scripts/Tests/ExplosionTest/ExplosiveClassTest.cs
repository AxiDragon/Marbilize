using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveClassTest : MonoBehaviour
{
    void Start()
    {
        TestBullet dangerousBullet = new TestBullet(500f, 150f);
        dangerousBullet.BeScary();
    }

    void Update()
    {
        
    }
}

class TestBullet
{
    public float explosionForce;
    public float speed;
    static int BulletAmount;
    public TestBullet(float _explosionForce, float _speed)
    {
        _explosionForce = explosionForce;
        _speed = speed;
        BulletAmount++;
    }

    public void BeScary()
    {
        Debug.Log("This bullet will hit you for " + explosionForce + " damage, at " + speed + " velocity!");
    }
}