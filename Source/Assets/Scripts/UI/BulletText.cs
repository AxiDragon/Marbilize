using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletText : MonoBehaviour
{
    public void ChangeBulletText(string bulletName)
    {
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
            text.text = bulletName;
    }
}
