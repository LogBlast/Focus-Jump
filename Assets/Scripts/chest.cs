
using UnityEngine;
using UnityEngine.UI;

public class chest : MonoBehaviour
{
    private Text interactUI;

    private bool isInRange;

    public Animator animator;
    public int coinsToAdd;
    

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            OpenChest();
        }
    }
    void OpenChest()
    {
        animator.SetTrigger("openChest");
        Inventory.instance.AddCoins(coinsToAdd);
        GetComponent<BoxCollider2D>().enabled = false;
        interactUI.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
