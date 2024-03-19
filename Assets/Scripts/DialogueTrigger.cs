using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;

    // Booléen pour vérifier si le joueur est à portée du déclencheur cet à dire du PNJ
    public bool isInRange;
    // Référence au texte de l'interface utilisateur pour l'interaction
    private Text interactUI;

    void Update()
    {
        // Vérifie si la touche E est enfoncée et si le joueur est à portée du déclencheur
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            // Déclenche le dialogue
            TriggerDialogue();
        }
    }

    void Awake()
    {
        // Initialise la référence au texte de l'interface utilisateur pour l'interaction
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Déclenché lorsque quelque chose entre dans le déclencheur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si le joueur est entré dans le déclencheur
        if (collision.CompareTag("Player"))
        {
            // Le joueur est à portée du déclencheur
            isInRange = true;
            // Active le texte de l'interface utilisateur pour l'interaction
            interactUI.enabled = true;
        }
    }

    // Déclenché lorsque quelque chose sort du déclencheur
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Vérifie si le joueur est sorti du déclencheur
        if (collision.CompareTag("Player"))
        {
            // Le joueur n'est plus à portée du déclencheur
            isInRange = false;
            // Désactive le texte de l'interface utilisateur pour l'interaction
            interactUI.enabled = false;
            // Termine le dialogue actuel s'il y en a un en cours
            DialogueManager.instance.EndDialogue();
        }
    }

    // Déclenche le dialogue
    void TriggerDialogue()
    {
        // Démarre le dialogue en utilisant le gestionnaire de dialogue
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
