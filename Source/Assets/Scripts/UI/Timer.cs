using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft, fullColorTime;
    Image image;
    Color startColor;
    Color endColor = Color.gray;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        startColor = texts[0].color;
        StartCoroutine(SetTimer(2f));
    }

    public IEnumerator SetTimer(float targetTime)
    {
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
    }
}
