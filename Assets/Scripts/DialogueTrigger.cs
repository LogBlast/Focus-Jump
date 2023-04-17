using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool isInRange;
    private Text interactUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TriggerDialogue();
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

            DialogueManager.instance.EndDialogue();
        }
    }
    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }

}
