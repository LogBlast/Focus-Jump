using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class JumpBar : MonoBehaviour
{
    public Slider slider; // R�f�rence au composant Slider dans l'interface graphique
    public bool isGrounded; // V�rifie si le personnage est au sol
    public Transform groundCheck; // Point de v�rification pour la collision avec le sol
    public float groundCheckRadius; // Rayon de la v�rification de collision
    public LayerMask collisionLayers; // Masque de collision pour d�finir les couches avec lesquelles le personnage peut interagir
    Coroutine c; // R�f�rence � la coroutine pour pouvoir l'arr�ter si n�cessaire
    public GameObject gameO; // R�f�rence � un objet � afficher ou � masquer pendant le saut
    public Gradient gradient;
    public Image fill;
    public float duration; // Dur�e totale de l'animation




    void Update()
    {

        

        




        // Si le bouton de saut est appuy� et le personnage est au sol
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Lancer la coroutine pour animer la barre de saut
            c = StartCoroutine(sliderAnimation());

            // Afficher l'objet sp�cifi�
            gameO.transform.localScale = new Vector3(1, 1, 1);

            fill.color = gradient.Evaluate(1f);
            
        }

        // Si le bouton de saut est rel�ch� et le personnage est au sol
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            // Masquer l'objet sp�cifi�
            gameO.transform.localScale = new Vector3(0, 0, 0);

            // Si la coroutine est en cours d'ex�cution, l'arr�ter
            if (c != null)
            {
                StopCoroutine(c);
            }
        }
    }
    


   



    void Start()
    {
        

        // Masquer l'objet sp�cifi� au d�marrage
        gameO.transform.localScale = new Vector3(0, 0, 0);
    }

    private void LateUpdate()
    {

        

    }

    void FixedUpdate()
    {
        // V�rifier si le personnage est au sol en effectuant une collision avec un cercle de rayon groundCheckRadius
        // autour du point groundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        //transform.position = player.transform.position + offset;
        // D�placer la jumpBar en utilisant la position du player et l'offset sp�cifi�

        


    }

    public void SetMinJump(int force)
    {
        // D�finir la valeur minimale de la barre de saut et la valeur initiale
        slider.minValue = force;
        slider.value = force;
    }

    IEnumerator sliderAnimation()
    {
        float elapsedTime = 0; // Temps �coul� depuis le d�but de l'animation
        float startValue = 0f; // Valeur de d�part de la barre de saut
        float endValue = 1f; // Valeur de fin de la barre de saut

        // Tant que le temps �coul� est inf�rieur � la dur�e totale
        while (elapsedTime < duration)
        {
            fill.color = gradient.Evaluate(slider.normalizedValue);
            // Augmenter le temps �coul� de la dur�e entre deux frames
            elapsedTime += Time.deltaTime;
            // Calculer la progression de l'animation entre 0 et 1
            float t = elapsedTime / duration;
            // D�finir la valeur de la barre de saut en fonction de la progression de l'animation
            slider.value = Mathf.Lerp(startValue, endValue, t);
            yield return null; // Attendre la prochaine frame
        }

    }
}