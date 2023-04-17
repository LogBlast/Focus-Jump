using UnityEngine;
using UnityEngine.UI;
public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    public int coinsToAdd;
    public AudioClip kIllSound;
    // fonction lu a chaque fois qu'on rentre dans le WeakSpot, l'attribut collision correspond a ce qui est rentr� dans le WeakSpot

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //on verifie que l'objet qui a frapp� le weakSpot a bien comme tag "Player"
        //dans Unity on tag le gameObject Player avec le tag Player
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(kIllSound, transform.position);
            Inventory.instance.AddCoins(coinsToAdd);
            //lorsque Player rentre dans le WeakSpot on detruit le gameObject Ennemi avec tout ce qu'il contient(grapichs, wayPoint1, ect...)
            Destroy(objectToDestroy);

        }




    }
}
