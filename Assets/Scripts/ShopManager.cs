using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Animator animator;
    public Text pnjNameText;
    public GameObject sellButton;
    public Transform sellButtonParent;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
            return;
        }
        instance = this;
        
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        pnjNameText.text = pnjName;
        UpdateItemToSell(items);
        animator.SetBool("isOpen", true);
    }


    public void UpdateItemToSell(Item[] items)
    {
        //supprime les boutons qui servent d'exemple dans le panel 
        for (int i = 0; i < sellButtonParent.childCount; i++)
        {
            Destroy(sellButtonParent.GetChild(i).gameObject);
        }

        //cree un bouton pour chauqe item dans la liste
        for (int i = 0; i < items.Length; i++)
        {
         GameObject button =    Instantiate(sellButton, sellButtonParent);
            SellButtonItem buttonScript = button.GetComponent<SellButtonItem>();
            buttonScript.itemName.text = items[i].nameObject;
            buttonScript.itemImage.sprite = items[i].image;
            buttonScript.itemPrice.text = items[i].price.ToString();
            buttonScript.item = items[i];
            button.GetComponent<Button>().onClick.AddListener(delegate { buttonScript.BuyItem(); }); //ajoute dans la methode Onclick() du button un listener et configuere les elements qu'on appel
        }

    }

    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }


}
