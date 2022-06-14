using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safebox : MonoBehaviour
{
    GameObject startPos;
    Timer timer;
    private void Start()
    {
        startPos = LevelStats.CurrentZone.transform.Find("StartPosition").gameObject;
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = startPos.transform.position;
            if (timer)
                timer.timeLeft -= 5f;
        }
        else
            Destroy(other.gameObject);
    }
}
