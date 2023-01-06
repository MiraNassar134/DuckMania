using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void closeWindow();

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
        closeWindow();
    }
}

