using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public float TimeLeft
    {
        get { return timeLeft; }
        set 
        {
            timeLeft = value;

            if (!countingDown)
                StartCoroutine(SetTimer(timeLeft));
        }
    }

    public float fullColorTime;
    Image image;
    Color startColor;
    Color endColor = Color.gray;
    bool countingDown;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        startColor = texts[0].color;
        StartCoroutine(SetTimer(timeLeft));
    }

    public void GetTime(float increment)
    {
        TimeLeft += increment * ItemStats.shieldGainModifier;
    }

    public void GetClearZoneTime()
    {
        TimeLeft += (2f + (8f - Mathf.Pow(LevelStats.Difficulty, 1f / 2.5f))) * ItemStats.shieldGainModifier;
    }

    public IEnumerator SetTimer(float targetTime)
    {
        countingDown = true;

        timeLeft = targetTime;
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        while (timeLeft > 0f)
        {
            Color color = Color.Lerp(endColor, startColor, timeLeft / fullColorTime);

            timeLeft -= Time.deltaTime;
            foreach (TextMeshProUGUI text in texts)
            {
                text.text = timeLeft.ToString("F2");
                text.color = color;
            }

            image.color = color;

            yield return null;
        }

        timeLeft = 0f; 
        foreach (TextMeshProUGUI text in texts)
        {
            text.text = timeLeft.ToString("F2");
        }

        countingDown = false;
    }
}
