using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class HealthShop : MonoBehaviour
{
    BaseCamp baseCamp;
    TokenManager tokenManager;
    Timer timer;
    public TextMeshPro costText;

    int cost = 1;
    int Cost
    {
        get { return cost; }
        set
        {
            cost = value;
            costText.text = value.ToString();
        }
    }

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
        if (tokenManager.Tokens >= Cost)
        {
            tokenManager.Tokens -= Cost;
            Cost *= 2;
            timer.GetTime(5f);
        }
    }
}
