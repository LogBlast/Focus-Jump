
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;

    private bool isInRange;

    public Item item;

    public AudioClip soundToPlay;


    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }


    void Update()
    {
        //si l'on appuie sur E et qu'on est à la bonne distance du coffre
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
        }
    }
    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si l'on est à la bonne distance du coffre le message va s'afficher et isInRange va être vrai
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    //Si 
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si l'on est pas à la bonne distance isInRange va être false et le message va être désactivé
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}
