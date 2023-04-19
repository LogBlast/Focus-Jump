using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int contentCurrentIndex=0;

    public List<Item> content = new List<Item>();
    public Image itemImageUI;
    public Sprite emptyImage;
    public Text itemNameUI;

    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance; //la variable static nous permet d'acceder a l'inventaire depuis n'importe ou 
    public PlayerEffects playerEffects;
    public AudioClip Sound;

    //Permet de gerer l'inventaire 
    private void Awake()
    {
        // Pour etre sur que l'inventaire soit unique, dans la scene il n'y a qu'un seul inventaire
        if(instance != null)
        {

            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scene");
                return; 

        }

        // l'inventaire est stocke dans " instance"
        instance = this; 

    }



    private void Start()
    {
        UpdateInventoryUI();
    }

    public void GetNextItem()
    {

        if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {

            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();//met a jour la photo de l'item

    }

    public void GetPreviousItem()
    {

        if (content.Count ==0)
        {
            return;
        }
        contentCurrentIndex--;

        if(contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1; 

        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
            itemImageUI.sprite = content[contentCurrentIndex].image; //le dernier .image viens du script item public Sprite image;
            itemNameUI.text = content[contentCurrentIndex].nameObject;

        }
        else
        {
            itemImageUI.sprite = emptyImage;
            itemNameUI.text = "Aucun Item";
        }
       
    }




    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }

        Item currentItem = content[contentCurrentIndex];
        // PlayerHealth.instance.healPlayer(currentItem.hpGiven);
        playerEffects.AddSpeed(currentItem.speedGiven, currentItem.speedDuration);//recupere la valeur de la potion de vitesse 
        playerEffects.AddJumpForce(currentItem.powerJump, currentItem.jumpDuration);//recupere la valeur saut

        AudioManager.instance.PlayClipAt(Sound, transform.position);
        content.Remove(currentItem);
        GetNextItem();
        UpdateInventoryUI();
    }

    public void AddCoins(int count)
    {

        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }

}
