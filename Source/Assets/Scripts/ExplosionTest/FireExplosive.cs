using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosive : MonoBehaviour
{
    public GameObject explosive;
    public float fireForce;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject shot = Instantiate(explosive, transform.position + transform.forward, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * fireForce, ForceMode.Impulse);
        }
    }
}
