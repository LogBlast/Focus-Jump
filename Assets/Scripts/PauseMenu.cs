using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject settingsWindow;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   //si la touche "échap" est appuyé
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }


    void Paused()
    {

        // activer notre menu pause / l'afficher
        // arreter le temps
        // changer le statut du jeu

        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;       // TimeScale = échelle du temps  / représente à quelle durée va s'écouler le temps (de base c'est 1)
        gameIsPaused = true;

    }

    public void Resume()
    {

        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;       // TimeScale = échelle du temps  / représente à quelle durée va s'écouler le temps (de base c'est 1)
        gameIsPaused = false;

    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

}
