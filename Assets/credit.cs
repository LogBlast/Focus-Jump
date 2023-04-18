using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class credit : MonoBehaviour
{
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            LoadMainMenu();
        }

    }
}
