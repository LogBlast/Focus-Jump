using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{


    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance; //la variable static nous permet d'acceder a l'inventaire depuis n'importe ou 


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


    public void AddCoins(int count)
    {

        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
}
