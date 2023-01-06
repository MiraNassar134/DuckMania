using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{

    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
    public void PauseGame()
    {
        Debug.Log("Pausing");
        // PausePanel.SetActive(true);
        SceneManager.LoadScene("pauseScene", LoadSceneMode.Additive);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void ResumeGame()
    {
        Debug.Log("Resuming");

        if (SceneManager.GetSceneByName("pauseScene").IsValid())
        {
            SceneManager.UnloadSceneAsync("pauseScene");
        }

        Time.timeScale = 1f;
        isPaused = false;


    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

