using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public bool isInRange;
    private Text interactUI;
    public Item[] itemsToSell;
    public string pnjName;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            ShopManager.instance.OpenShop(itemsToSell, pnjName);

            //DialogueManager.instance.StartDialogueShop();
        }
    }
    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            interactUI.enabled = false;
            ShopManager.instance.CloseShop();
           // DialogueManager.instance.EndDialogueShop();
            //DialogueManager.instance.EndDialogue();
        }
    }
}
