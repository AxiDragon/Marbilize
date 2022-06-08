using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    public UnityEvent gamerEvent;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //? = if there are no subscribers, don't execute this (prevents errors)
            gamerEvent?.Invoke();
        }
    }

    [ContextMenu("Test Function")]
    void TestFunction()
    {
        print("hello it me owo");
    }
}
