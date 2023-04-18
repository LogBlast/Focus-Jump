using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // ctrl + b --> Build and Run.

    public GameObject settingWindow;

    public string levelToLoad;
    public void StartGame(){
        SceneManager.LoadScene(levelToLoad);
    }

     public void SettingsButton(){
        settingWindow.SetActive(true);
    }

    public void CloseSettingsWindow(){
        settingWindow.SetActive(false);
    }

    public void LoadCredits(){
        SceneManager.LoadScene("Credit");
    }   

     public void QuitGame(){
        Application.Quit();
    }

    


}
