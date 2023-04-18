
using UnityEngine;
[CreateAssetMenu(fileName="Item", menuName = "Inventory/Item")]//cree un menu dans unity asset->create->Inventory->Item  pour gerer les Items du jeux
public class Item : ScriptableObject // DIFFERENT DE D4HABITUDE, aller voir la video scriptable object
{

    public int id;
    public string nameObject;
    public string description;
    public Sprite image; //pour mettre l'image de la potion
    public int price;

    public int hpGiven;
    public int speedGiven;
    public int speedDuration;


}
