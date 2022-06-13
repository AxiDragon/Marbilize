using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static IEnumerator Feedback(GameObject[] gameObjects, float feedbackTime, Vector3[] startScale)
    {
        float timer = 0f;
        while (timer < feedbackTime)
        {

            for (int i = 0; i < gameObjects.Length; i++)
            {
                Vector3 newScale = Vector3.Lerp(startScale[i], startScale[i] * 1.2f, Mathf.PingPong(timer / (feedbackTime / 2f), 1f));
                gameObjects[i].transform.localScale = newScale;

            }

            timer += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].transform.localScale = startScale[i];
    }
}
