using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoolScript1 : MonoBehaviour
{
    UnityEventTest unityEventTest;
    public Ability[] allAbilities;
    void Start()
    {
        unityEventTest = FindObjectOfType<UnityEventTest>();
    }

    public void BecomeGamer()
    {
        print("I am now a gamer");
    }
}
