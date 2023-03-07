using UnityEngine.SceneManagement; //Pour switch les scenes
using UnityEngine;

public class LoadSpecificScene : MonoBehaviour
{

    public string sceneName;






    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);

        }
    }
}
