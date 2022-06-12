using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public float maxHealth = 10f;
    float health;
    Timer timer;
    Image image;
    Color startColor;
    Color endColor = Color.gray;

    bool healthUp = false;

    private void Start()
    {
        health = maxHealth;

        timer = FindObjectOfType<Timer>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        image = GetComponentInChildren<Image>();
        startColor = texts[0].color;

        foreach (TextMeshProUGUI text in texts)
            text.text = health.ToString("F1");
    }

    void Update()
    {
        if (timer.timeLeft == 0f && !healthUp)
        {
            health -= Time.deltaTime;
            Color color = Color.Lerp(endColor, startColor, health / maxHealth);

            TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

            foreach (TextMeshProUGUI text in texts)
            {
                text.text = health.ToString("F1");
                text.color = color;
            }

            image.color = color;
        }

        if (health <= 0f && !healthUp)
        {
            healthUp = true;
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
