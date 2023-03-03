using UnityEngine;

public class PickUpObject : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //on verifie que l'objet qui a frappé le weakSpot a bien comme tag "Player". Dans Unity on tag le gameObject Player avec le tag Player
        if (collision.CompareTag("Player"))
        {

            //Permet d'ajouter une piece collecter par le joueur au compteur avant de la detruire
            Inventory.instance.AddCoins(1);

            //lorsque Player rentre dans le collider de la piece on detruit le gameObject Coin
            Destroy(gameObject);

        }

    }
}
