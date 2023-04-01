using UnityEngine;
using System;
public class PlayerMovement : MonoBehaviour
{
    public bool StartJumping ;
    public bool isGrounded;
   // public bool saut = false;
    public bool canMove;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public float moveSpeed;
    public float jumpForce;

    public DateTime jumpStart;
    public DateTime jumpEnd;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    
    public float delayJump;

  //  private float jumpDirection;

    public static PlayerMovement instance;


    //ajout pour la barre qui suit le joueur 
   // public GameObject player;
    //public float timeOffset;
    //public Vector3 posOffset;

    public PhysicsMaterial2D bounceMat, normalMat;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }

        instance = this;
    }




    void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);

        //Quand tu appuie sur espace et que tu est au sol
        // touche native de Unity qui représente la barre espace
        if (Input.GetButtonDown("Jump") && isGrounded)  {
            //le timer de saut se lance
            jumpStart = DateTime.Now;
            StartJumping = true;

            //reset les mouvements du personnage
            rb.velocity = Vector3.zero;  

            canMove = false;

            //Le systeme qui gere les animations (animator) recoit la variable canMove et switch les animations courir, repos a charger le saut 
            animator.SetBool("canMove", false);

            

        }

       



        //Quand on relache le bouton espace et qu'on est au sol et qu'on a commencer a sauter
        if (Input.GetButtonUp("Jump")  && isGrounded && jumpStart != DateTime.MinValue){  

            jumpEnd = DateTime.Now;
           // StartJumping = true; //le perso decole du sol
           

            canMove = true;
            
            

           
            
            //Le systeme qui gere les animations (animator) recoit la variable canMove et switch l'animation charger le saut a courir ou repos 
            animator.SetBool("canMove", true);
            


        }

       
        
        //Permet de retourner le personnage en fonction de son axe de deplacement
        Flip(rb.velocity.x);

        //definie la vitesse du personnage sur l'axe x
        float characterVelocity = Mathf.Abs(rb.velocity.x);

        //Le systeme qui gere les animations (animator) recoit la variable Speed et switch l'animation repos a courir
        animator.SetFloat("Speed", characterVelocity); 

        //ajout de l'effet de rebond quand on cogne les murs
        if(jumpForce > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

        
       
       

    }

    // en permanence

    void FixedUpdate()
    {
        // On vérifie si le joueur peut se déplacer.
        if (canMove)
        {
            //empecher de changer de direction en l'air; je laisse canMove = true a ce moment sinon pas de force dans le saut je l'empche juste de tourner a droite ou a gauche
            //horizontalMovement vaut 0 donc pas de mouvement mais une force de saut uniquement
            if (isGrounded)
            {
                // On récupère la valeur de l'axe horizontal (gauche/droite) du clavier et on multiplie par la vitesse de déplacement
                // et le temps écoulé depuis la dernière frame pour obtenir la distance parcourue horizontalement.
                horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            }
            
            // On déplace le joueur en utilisant la direction récupérée.
            MovePlayer(horizontalMovement);
        }



        // On vérifie si le joueur est actuellement au sol en utilisant un cercle de rayon groundCheckRadius
        // centré sur la position groundCheck.position du joueur. Si ce cercle touche un layer appartenant
        // à la liste collisionLayers, alors le joueur est considéré comme étant au sol.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);



        


    }


    // Cette fonction permet de déplacer le joueur en fonction de sa direction 
    // convention de nomage _var
    void MovePlayer(float _horizontalMovement)
    {




        // la direction vers laquelle on va se déplacer va être basé sur _horiz (axe X) et l'axe vertical (Y) 
        // rb.velocity.y --> va prendre la valeur par défaut de la force du rigidbody
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);

        //rend le mouvement du joueur plus agreable visuellement
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        // Si le joueur est en train de sauter
        if (StartJumping == true)
        {
            // On calcule la durée du saut en millisecondes
            int dif_jump = (int)(jumpEnd - jumpStart).TotalMilliseconds;

            // Si le saut a duré plus de 2 secondes, on applique une force maximale
            if (dif_jump >= delayJump*1000)
            {
                //on saute a la puissance max + la puissance de saut minimum
                rb.AddForce(new Vector2(0f, jumpForce+250));
                
            }

            // Sinon, on applique une force proportionnelle à la durée du saut
            else
            {
                float force;
                force = jumpForce * (float)(dif_jump / (delayJump * 1000.0));
                rb.AddForce(new Vector2(0f, force+250));
            }

            // On désactive le booléen isJumping pour indiquer que le joueur a terminé son saut, et on réinitialise la valeur de jumpStart
            
            StartJumping = false;
            jumpStart = DateTime.MinValue;

        }

    }

    void Flip(float velocity)
    {

        if (velocity > 0.1f)
        {   // si la vélocité est positive, alors le modèle du personage est tourné vers la droite

            spriteRenderer.flipX = false;

        }

        else if (velocity < -0.1f)
        {  // si la vélocité est négative, alors le modèle du personage est tourné vers la gauche

            spriteRenderer.flipX = true;
        }

        // la vélocité est compris entre -1 et 1
    }


    //Permet de dessiner un cercle rouge pour voir ou le personnage touche concretement le sol
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }



}


