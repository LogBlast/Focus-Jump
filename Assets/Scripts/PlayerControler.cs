using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    
    
    
    void Update() {

         

        if (Input.GetButtonDown("Jump") && isGrounded){ // touche native de Unity qui représente la barre espace  
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);

        animator.SetFloat("Speed", characterVelocity);

        


        
    }

    // en permanence

    void FixedUpdate() {

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        MovePlayer(horizontalMovement);
        
    }
    


    void  MovePlayer(float _horizontalMovement) { // convention de nomage _var


        // la direction vers laquelle on va se déplacer va être basé sur _horiz (axe X) et l'axe vertical (Y)  // rb.velocity.y --> va prendre la valeur par défaut de la force du rigidbody
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);  

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
   
        if(isJumping == true){

            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    
    }

    void Flip(float velocity){

        if(velocity > 0.1f){   // si la vélocité est positive, alors le modèle du personage est tourné vers la droite

            spriteRenderer.flipX=false;

        }

        else if(velocity<-0.1f){  // si la vélocité est négative, alors le modèle du personage est tourné vers la gauche

            spriteRenderer.flipX=true;  
        }

        // la vélocité est compris entre -1 et 1
    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius); 
    }


}


/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;


    public float moveSpeed;
    public float jumpForce;

    public Rigidbody2D rb;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    


    void Update() {
        if(Input.GetButtonDown("Jump") && isGrounded){  // touche native de Unity qui représente la barre espace
            isJumping = true;
        }
    }

    // en permanence
    void FixedUpdate() {

        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position,groundCheckRight.position);  
        // Va créer une boite de colision entre le 1er et le 2eme élèment 


       float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;   // time.deltaTime == temps qu'on reste appuyer sur la touche

        MovePlayer(horizontalMovement);
        Flip(rb.velocity.x);


        float characterVelocity = Mathf.Abs(rb.velocity.x);  // renvoie toujours une valeur positive
        animator.SetFloat("Speed",characterVelocity);
    }
    
    void  MovePlayer(float _horizontalMovement) {  // convention de nomage _var
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);  // la direction vers laquelle on va se déplacer va être basé sur _horiz (axe X) et l'axe vertical (Y)
        // rb.velocity.y --> va prendre la valeur par défaut de la force du rigidbody

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    
        if(isJumping == true){
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    
    }

    void Flip(float velocity){
        if(velocity > 0.1f){   // si la vélocité est positive, alors le modèle du personage est tourné vers la droite
            spriteRenderer.flipX=false;
        }
        else if(velocity<-0.1f){  // si la vélocité est négative, alors le modèle du personage est tourné vers la gauche
            spriteRenderer.flipX=true;  
        }

        // la vélocité est compris entre -1 et 1
    }   


}
*/
