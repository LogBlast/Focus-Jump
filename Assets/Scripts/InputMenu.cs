using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputMenu : MonoBehaviour
{
    
    public GameObject InputMenuUI;

    public GameObject settingsInputWindow;


    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   //si la touche "�chap" est appuy�
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }*/


  /*  void Paused()
    {

        // activer notre menu pause / l'afficher
        // arreter le temps
        // changer le statut du jeu

        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;       // TimeScale = �chelle du temps  / repr�sente � quelle dur�e va s'�couler le temps (de base c'est 1)
        gameIsPaused = true;

    }*/

   /* public void Resume()
    {

        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;       // TimeScale = �chelle du temps  / repr�sente � quelle dur�e va s'�couler le temps (de base c'est 1)
        gameIsPaused = false;

    }
   */

    /*public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }*/

    public void InputButton()
    {
        settingsInputWindow.SetActive(true);
    }

    public void CloseInputWindow()
    {
        settingsInputWindow.SetActive(false);
    }

}
