using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public static bool tutorial = false;

    private void Start()
    {
        tutorial = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void StartTutorial()
    {
        tutorial = true;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
