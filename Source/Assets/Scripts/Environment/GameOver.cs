using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public IEnumerator GameOvered()
    {
        float timer = 0f;
        float maxTime = 1f;
        Image fade = GetComponent<Image>();

        while (timer < maxTime)
        {
            timer += Time.deltaTime;
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, timer);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
