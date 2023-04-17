using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    
    public Text nomText;
    public Text dialogueText;
    private Queue<string> phrases;

    public Animator animator;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance dans la scène");
            return;
        }
        instance = this;
        phrases = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("isOpen", true);
        nomText.text = dialogue.nom;

        phrases.Clear();

        foreach(string phrase in dialogue.phrase)
        {
            //permet de rentrer la phrase dans la file d'attente
            phrases.Enqueue(phrase);
        }
        DisplayNextPhrase();
    }

    public void DisplayNextPhrase()
    {
        if (phrases.Count == 0)
        {
            EndDialogue();
            return;
        }
        string phrase = phrases.Dequeue();
        //permet d'arrêter l'effet quand l'utilisateur veut passer le dialogue
        StopAllCoroutines();
        StartCoroutine(TaperPhrase(phrase));
    }
    //Cette fonction va nous permettre d'avoir un effet d'affichage du dialogue
    IEnumerator TaperPhrase(string phrase)
    {
        dialogueText.text = "";
        foreach(char lettre in phrase.ToCharArray())
        {
            dialogueText.text += lettre;
            yield return new WaitForSeconds(0.05f);
        }
    }
     public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
