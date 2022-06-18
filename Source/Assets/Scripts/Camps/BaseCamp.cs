using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamp : MonoBehaviour
{
    Light spotlight;
    GameObject player;
    float enterIntensity = 3000f;
    float exitIntensity = 500f;
    
    public bool lit = false;


    void Start()
    {
        spotlight = GetComponent<Light>();
        player = GameObject.Find("Player");
        print(name);
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 15f)
        {
            print("a");
            lit = true;
            spotlight.intensity = enterIntensity;
        }
        else
        {
            print("b");
            lit = false;
            spotlight.intensity = exitIntensity;
        }
    }

    private void OnMouseExit()
    {
        lit = false;
        spotlight.intensity = exitIntensity;
    }

    private void OnDisable()
    {
        spotlight.intensity = exitIntensity;
    }
}
