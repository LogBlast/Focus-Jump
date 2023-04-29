using UnityEngine.SceneManagement; //Pour switch les scenes
using UnityEngine;
using UnityEngine.UI;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName;
    public GameObject JumpBar;
    public Button btnG;
    public Button btnD;
    public Button btnUseItem;
    public GameObject CoinsCount;
    public GameObject textJumpBar;
    public GameObject textUseItem;




    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if (collision.CompareTag("Player"))
        {
            if (sceneName == "credit")
            {
                JumpBar.SetActive(false);
                btnG.gameObject.SetActive(false);
                btnD.gameObject.SetActive(false);
                btnUseItem.gameObject.SetActive(false);
                CoinsCount.gameObject.SetActive(false);
                textJumpBar.gameObject.SetActive(false);
                textUseItem.gameObject.SetActive(false);
            }

            SceneManager.LoadScene(sceneName);

        }
    }
}
