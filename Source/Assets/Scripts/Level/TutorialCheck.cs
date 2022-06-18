using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    void Start()
    {
        if (!MenuButtons.tutorial)
            Destroy(gameObject);
    }
}
