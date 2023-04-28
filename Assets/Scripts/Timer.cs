using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public Text timeText;
    public bool isActive = true; // ajout de la variable isActive

    private void Update()
    {
        if (isActive) // vérifie si isActive est vrai
        {
            timeRemaining += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);

            timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        }



    }


  

}
