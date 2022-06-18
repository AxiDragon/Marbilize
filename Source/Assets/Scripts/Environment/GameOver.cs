using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    ScoreManager scoreManager;
    List<GameObject> gameObjects = new List<GameObject>();

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        foreach (Transform child in transform)
        {
            gameObjects.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public void StartGameOver()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator GameOvered()
    {
        for (int i = 0; i < gameObjects.Count; i++)
            gameObjects[i].SetActive(true);

        float timer = 0f;
        float maxTime = 1f;
        CanvasGroup group = GetComponent<CanvasGroup>();
        TextMeshProUGUI textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        textMeshProUGUI.text = scoreManager.Score.ToString();

        while (timer < maxTime)
        {
            timer += Time.deltaTime;
            group.alpha = timer;
            yield return null;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
