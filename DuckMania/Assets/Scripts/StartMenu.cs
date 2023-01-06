using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void closeWindow();

    // Start is called before the first frame update
    public static bool gameloaded = false;
    void Start()
    {

        if (gameloaded)
        {

            if (SceneManager.GetSceneByName("pauseScene").IsValid())
            {
                SceneManager.UnloadSceneAsync("pauseScene");
            }

            if (SceneManager.GetSceneByName("DuckMania").IsValid())
            {
                SceneManager.UnloadSceneAsync("DuckMania");
            }

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

        Time.timeScale = 1f;
        PauseMenuScript.isPaused = false;
        gameloaded = true;

        SceneManager.LoadScene("DuckMania", LoadSceneMode.Additive);
    }
    public void ExitGame()
    {
        Application.Quit();
        closeWindow();
    }
}
