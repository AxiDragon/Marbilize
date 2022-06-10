using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLoader : MonoBehaviour
{
    public ScriptableBulletTest bullet;
    
    void Start()
    {
        print(bullet.explosionForce);
    }
}
