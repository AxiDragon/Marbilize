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

        StartCoroutine(UIManager.Feedback(new GameObject[] { texts[0].gameObject }, 
            feedbackTime, new Vector3[] { startingScale }));
    }
}
