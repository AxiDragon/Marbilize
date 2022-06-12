using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    private void Start()
    {
        StartCoroutine(SetTimer(10f));
    }

    public IEnumerator SetTimer(float targetTime)
    {
        timeLeft = targetTime;
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        while (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;
            foreach (TextMeshProUGUI text in texts)
            {
                text.text = timeLeft.ToString("F2");
            }
            yield return null;
        }

        timeLeft = 0f; 
        foreach (TextMeshProUGUI text in texts)
        {
            text.text = timeLeft.ToString("F2");
        }
    }
}
