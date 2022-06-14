using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateUI();
        }
    }

    float feedbackTime = 0.2f;
    bool flashing = false;
    Image image;
    TextMeshProUGUI text;
    Vector3 imageStartScale, textStartScale;

    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponentInChildren<Image>();

        imageStartScale = image.transform.localScale;
        textStartScale = text.transform.localScale;

        text.text = score.ToString();
    }

    public void UpdateScore() => Score++;

    void UpdateUI()
    {
        text.text = score.ToString();
        if (!flashing)
        {
            StartCoroutine(Cooldown());
            StartCoroutine(UIManager.Feedback(new GameObject[] { image.gameObject, text.gameObject }, feedbackTime,
                new Vector3[] { imageStartScale, textStartScale }));
        }
    }

    IEnumerator Cooldown()
    {
        flashing = true;
        float timer = 0f;
        while (timer < feedbackTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        flashing = false;
    }
}
