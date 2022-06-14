using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthShop : MonoBehaviour
{
    BaseCamp baseCamp;
    TokenManager tokenManager;
    Timer timer;

    void Start()
    {
        tokenManager = FindObjectOfType<TokenManager>();
        baseCamp = GetComponent<BaseCamp>();
        timer = FindObjectOfType<Timer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && baseCamp.lit)
        {
            Buy();
        }
    }

    void Buy()
    {
        if (tokenManager.Tokens > 0)
        {
            tokenManager.Tokens--;
            timer.GetTime(5f);
        }
    }
}
