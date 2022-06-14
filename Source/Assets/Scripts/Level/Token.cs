using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Pickup();
    }

    void Pickup()
    {
        FindObjectOfType<TokenManager>().Tokens += 1;
        Destroy(gameObject);
    }
}
