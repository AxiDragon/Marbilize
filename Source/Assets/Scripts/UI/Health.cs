using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public float maxHealth = 10f;
    float heartbeatTime = 0.3f;
    [HideInInspector]
    public float health;
    Timer timer;
    Image image;
    Color startColor;
    Color endColor = Color.gray;
    Vector3 imageStartScale, textStartScale;
    AudioSource ost;

    bool healthUp = false;
    bool beating = false;

    private void Start()
    {
        health = maxHealth;

        ost = GameObject.Find("Player").GetComponent<AudioSource>();
        timer = FindObjectOfType<Timer>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        image = GetComponentInChildren<Image>();
        startColor = texts[0].color;
        imageStartScale = image.transform.localScale;
        textStartScale = texts[0].transform.localScale;

        foreach (TextMeshProUGUI text in texts)
            text.text = health.ToString("F1");
    }

    void Update()
    {
        if (timer.timeLeft == 0f && !healthUp)
        {
            DepleteHealth(1f);
        }

        if (!AboveVoidCheck.isInside)
        {
            DepleteHealth(3f);
        }

        if (health <= 0f && !healthUp)
        {
            healthUp = true;
            GameOver();
        }

    }

    public void DepleteHealth(float rate)
    {
        health -= Time.deltaTime * rate;
        Color color = Color.Lerp(endColor, startColor, health / maxHealth);
        ost.volume = Mathf.Lerp(0f, 0.5f, health / maxHealth);

        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
        {
            text.text = health.ToString("F1");
            text.color = color;
        }

        image.color = color;

        if (!beating)
        {
            StartCoroutine(Cooldown());
            StartCoroutine(UIManager.Feedback(new GameObject[] { image.gameObject, texts[0].gameObject }, heartbeatTime,
                new Vector3[] { imageStartScale, textStartScale }));
        }
    }

    void GameOver()
    {
        print("Game over!");
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        health = 0f;

        foreach (TextMeshProUGUI text in texts)
            text.text = health.ToString("F1");

        StartCoroutine(FindObjectOfType<GameOver>().GameOvered());
    }

    IEnumerator Cooldown()
    {
        beating = true;
        float timer = 0f;
        while (timer < heartbeatTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        beating = false;
    }
}
