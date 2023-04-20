using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class JumpBar : MonoBehaviour
{
    public Slider slider; // Référence au composant Slider dans l'interface graphique
    public bool isGrounded; // Vérifie si le personnage est au sol
    public Transform groundCheck; // Point de vérification pour la collision avec le sol
    public float groundCheckRadius; // Rayon de la vérification de collision
    public LayerMask collisionLayers; // Masque de collision pour définir les couches avec lesquelles le personnage peut interagir
    Coroutine c; // Référence à la coroutine pour pouvoir l'arrêter si nécessaire
    public GameObject gameO; // Référence à un objet à afficher ou à masquer pendant le saut
    public Gradient gradient;
    public Image fill;
    public float duration; // Durée totale de l'animation




    void Update()
    {

        

        




        // Si le bouton de saut est appuyé et le personnage est au sol
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Lancer la coroutine pour animer la barre de saut
            c = StartCoroutine(sliderAnimation());

            // Afficher l'objet spécifié
            gameO.transform.localScale = new Vector3(1, 1, 1);

            fill.color = gradient.Evaluate(1f);
            
        }

        // Si le bouton de saut est relâché et le personnage est au sol
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            // Masquer l'objet spécifié
            gameO.transform.localScale = new Vector3(0, 0, 0);

            // Si la coroutine est en cours d'exécution, l'arrêter
            if (c != null)
            {
                StopCoroutine(c);
            }
        }
    }
    


   



    void Start()
    {
        

        // Masquer l'objet spécifié au démarrage
        gameO.transform.localScale = new Vector3(0, 0, 0);
    }

    private void LateUpdate()
    {

        

    }

    void FixedUpdate()
    {
        // Vérifier si le personnage est au sol en effectuant une collision avec un cercle de rayon groundCheckRadius
        // autour du point groundCheck
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        //transform.position = player.transform.position + offset;
        // Déplacer la jumpBar en utilisant la position du player et l'offset spécifié

        


    }

    public void SetMinJump(int force)
    {
        // Définir la valeur minimale de la barre de saut et la valeur initiale
        slider.minValue = force;
        slider.value = force;
    }

    IEnumerator sliderAnimation()
    {
        float elapsedTime = 0; // Temps écoulé depuis le début de l'animation
        float startValue = 0f; // Valeur de départ de la barre de saut
        float endValue = 1f; // Valeur de fin de la barre de saut

        // Tant que le temps écoulé est inférieur à la durée totale
        while (elapsedTime < duration)
        {
            fill.color = gradient.Evaluate(slider.normalizedValue);
            // Augmenter le temps écoulé de la durée entre deux frames
            elapsedTime += Time.deltaTime;
            // Calculer la progression de l'animation entre 0 et 1
            float t = elapsedTime / duration;
            // Définir la valeur de la barre de saut en fonction de la progression de l'animation
            slider.value = Mathf.Lerp(startValue, endValue, t);
            yield return null; // Attendre la prochaine frame
        }

    }
}