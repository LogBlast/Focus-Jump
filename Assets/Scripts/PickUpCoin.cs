using UnityEngine;

public class PickUpCoin : MonoBehaviour
{


    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //on verifie que l'objet qui a frapp� le weakSpot a bien comme tag "Player". Dans Unity on tag le gameObject Player avec le tag Player
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            //Permet d'ajouter une piece collecter par le joueur au compteur avant de la detruire
            Inventory.instance.AddCoins(1);

            //lorsque Player rentre dans le collider de la piece on detruit le gameObject Coin
            Destroy(gameObject);

        }

    }
}
