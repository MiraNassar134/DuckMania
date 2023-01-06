using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pausebuttons : MonoBehaviour
{


    [DllImport("__Internal")]
    private static extern void closeWindow();

    public void ResumeGame()
    {
        Debug.Log("Resuming");

        Time.timeScale = 1f;
        PauseMenuScript.isPaused = false;

        if (SceneManager.GetSceneByName("pauseScene").IsValid())
        {
            SceneManager.UnloadSceneAsync("pauseScene");
        }
    }

    // create main menu
    public void GotoMainMenu()
    {
        Debug.Log("going to main menu!");
        Time.timeScale = 0f;
        PauseMenuScript.isPaused = true;

        if (SceneManager.GetSceneByName("pauseScene").IsValid())
        {
            SceneManager.UnloadSceneAsync("pauseScene");
        }

        if (SceneManager.GetSceneByName("DuckMania").IsValid())
        {
            SceneManager.UnloadSceneAsync("DuckMania");
        }

        // Get a list of all game objects in the scene
        GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Destroy each game object
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }


        SceneManager.LoadScene("StartScreen", LoadSceneMode.Additive);
    }
    public void ExitGame()
    {
        Application.Quit();
        closeWindow();
    }
}
