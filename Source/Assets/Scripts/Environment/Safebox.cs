using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safebox : MonoBehaviour
{
    GameObject startPos;
    private void Start()
    {
        startPos = transform.root.Find("StartPosition").gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.transform.position = startPos.transform.position;
        else
            Destroy(other.gameObject);
    }
}
