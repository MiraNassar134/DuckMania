using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool gameloaded = false;
    void Start()
    {

        if (gameloaded)
        {
            SceneManager.UnloadSceneAsync("DuckMania");
            SceneManager.UnloadSceneAsync("pauseScene");
            SceneManager.LoadScene("StartScreen");
            gameloaded = false;
        }
        PauseMenuScript.isPaused = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        Debug.Log("Start");
        //PausePanel.SetActive(false);


        Time.timeScale = 1f;
        PauseMenuScript.isPaused = false;
        gameloaded = true;
        // SceneManager.UnloadSceneAsync("StartScreen");
        SceneManager.LoadScene("DuckMania", LoadSceneMode.Additive);


    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
