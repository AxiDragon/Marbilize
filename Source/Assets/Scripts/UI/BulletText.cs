using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletText : MonoBehaviour
{
    Vector3 startingScale;
    Vector3 startingScaleImage;
    public Image bulletImage;
    float feedbackTime = .2f;

    private void Start()
    {
        startingScale = GetComponentInChildren<TextMeshProUGUI>().transform.lossyScale;
        startingScaleImage = bulletImage.transform.lossyScale;
    }

    public void UpdateBulletText(ScriptableBullet bullet, int tier)
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
            text.text = bullet.bulletName;

        bulletImage.sprite = bullet.bulletSprite;

        StartCoroutine(UIManager.Feedback(new GameObject[] { texts[0].gameObject, bulletImage.gameObject }, 
            feedbackTime, new Vector3[] { startingScale, startingScaleImage }));
    }
}
