using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{

    public static bool isPaused=false;
    // public GameObject  PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        // PausePanel= GameObject.Find("Canvas").GetComponent<PausePanel>();
        // PausePanel.SetActive(false);
        Debug.Log("started");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("updating");
    // Console.WriteLine("updating");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        if(isPaused){
            ResumeGame();
            

        }
        else{
            PauseGame();
        }
        }
        
    }
    public void PauseGame(){
        Debug.Log("Pausing");
        // PausePanel.SetActive(true);
        SceneManager.LoadScene("pauseScene", LoadSceneMode.Additive);
        Time.timeScale=0f;
        isPaused=true;

    }
    public void ResumeGame(){
        Debug.Log("Resuming");
        //PausePanel.SetActive(false);
       
        SceneManager.UnloadSceneAsync("pauseScene");
        Time.timeScale=1f;
        isPaused=false;
        

    }
    //todo 
    // create main menu

    // public void GotoMainMenu(){
    //     Time.timeScale=1f;
    //     SceneManager.loadScene("MainMenu")
    // }
    public void ExitGame(){
        Application.Quit();
    }
}

