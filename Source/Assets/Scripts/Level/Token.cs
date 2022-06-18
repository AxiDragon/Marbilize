using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    private void Start()
    {
        Pickup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Pickup();
    }

    void Pickup()
    {
        TokenManager manager = FindObjectOfType<TokenManager>();
        manager.GetComponent<RandomizeAudio>().Randomize();
        manager.GetComponent<AudioSource>().Play();
        manager.Tokens += 1;
        Destroy(gameObject);
    }
}
