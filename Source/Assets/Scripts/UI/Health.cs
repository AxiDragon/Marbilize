using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public float health = 10f;
    Timer timer;

    bool healthUp = false;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
            text.text = health.ToString("F1");
    }

    void Update()
    {
        if (timer.timeLeft == 0f && !healthUp)
        {
            health -= Time.deltaTime;

            TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

            foreach (TextMeshProUGUI text in texts)
                text.text = health.ToString("F1");
        }

        if (health <= 0f && !healthUp)
        {
            healthUp = false;
            GameOver();
        }
    }

    void GameOver()
    {
        print("Game over!");
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        health = 0f;

        foreach (TextMeshProUGUI text in texts)
            text.text = health.ToString("F1");
    }
}
