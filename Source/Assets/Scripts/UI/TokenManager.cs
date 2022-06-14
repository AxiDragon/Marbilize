using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenManager : MonoBehaviour
{
    private int tokens = 0;
    public int Tokens
    {
        get { return tokens; }
        set
        {
            tokens = value;
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

        text.text = tokens.ToString();
    }

    void UpdateUI()
    {
        text.text = tokens.ToString();
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
