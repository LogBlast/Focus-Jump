
using UnityEngine;
using UnityEngine.UI;

public class chest : MonoBehaviour
{
    private Text interactUI;

    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
    public AudioClip chestSound;


    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    
    void Update()
    {
        //si l'on appuie sur E et qu'on est � la bonne distance du coffre
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }
    void OpenChest()
    {
        //si l'on ouvre le coffre on va avoir l'animation du coffre et pi�ce en plus d�cid� dans unity ensuite lorsque le coffre est ouvert on a plus le message affich� et on ne peux plus ouvrir le coffre
        animator.SetTrigger("openChest");
        AudioManager.instance.PlayClipAt(chestSound, transform.position);
        Inventory.instance.AddCoins(coinsToAdd);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si l'on est � la bonne distance du coffre le message va s'afficher et isInRange va �tre vrai
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    //Si 
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si l'on est pas � la bonne distance isInRange va �tre false et le message va �tre d�sactiv�
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
