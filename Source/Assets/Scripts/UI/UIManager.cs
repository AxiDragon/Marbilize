using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    MovementEnabler enabler;
    //bool paused = false;

    private void Start()
    {
        enabler = FindObjectOfType<MovementEnabler>();
    }

    //public void PauseMenu(InputAction.CallbackContext callback)
    //{
    //    if (!callback.action.WasPressedThisFrame())
    //        return;

    //    print("I made it here!");
    //    if (paused)
    //    {
    //        Time.timeScale = Time.timeScale;
    //        SlideUI(new GameObject[] { pauseMenu }, 0.2f, pauseMenu.transform.position, Vector3.down * 500f);
    //        enabler.Enable();
    //    }
    //    else
    //    {
    //        Time.timeScale = 0f;
    //        SlideUI(new GameObject[] { pauseMenu }, 0.2f, pauseMenu.transform.position, Vector3.zero);
    //        enabler.Disable();
    //    }

    //    paused = !paused;
    //}

    public static IEnumerator Feedback(GameObject[] gameObjects, float feedbackTime, Vector3[] startScale)
    {
        float timer = 0f;
        while (timer < feedbackTime)
        {

            for (int i = 0; i < gameObjects.Length; i++)
            {
                print(i);
                Vector3 newScale = Vector3.Lerp(startScale[i], startScale[i] * 1.2f, Mathf.PingPong(timer / (feedbackTime / 2f), 1f));
                gameObjects[i].transform.localScale = newScale;

            }

            timer += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].transform.localScale = startScale[i];
    }

    public static IEnumerator SlideUI(GameObject[] gos, float time, Vector3 startDestination, Vector3 endDestination)
    {
        float timer = 0f;
        while (timer < time)
        {
            for(int i = 0; i < gos.Length; i++)
            {
                gos[i].transform.position = Vector3.Slerp(startDestination, endDestination, timer / time);
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
