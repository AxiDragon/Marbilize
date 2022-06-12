using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletText : MonoBehaviour
{
    Vector3 startingScale;
    float feedbackTime = .2f;

    private void Start()
    {
        startingScale = GetComponentInChildren<TextMeshProUGUI>().transform.lossyScale;
    }

    public void UpdateBulletText(string bulletName, int tier)
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
            text.text = bulletName;

        StartCoroutine(Feedback(texts));
    }

    IEnumerator Feedback(TextMeshProUGUI[] texts)
    {
        float timer = 0f;
        while (timer < feedbackTime)
        {
            Vector3 newScale = Vector3.Lerp(startingScale, startingScale * 1.2f, Mathf.PingPong(timer / (feedbackTime / 2f), 1f));

            for (int i = 0; i < texts.Length; i++)
                texts[i].transform.localScale = newScale;

            timer += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < texts.Length; i++)
            texts[i].transform.localScale = startingScale;
    }
}
