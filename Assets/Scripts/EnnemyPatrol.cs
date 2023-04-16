using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{

    public float speed;
    public Transform[] wayPoints;
    private Transform target;
    private int destPoint=0;
    

    public SpriteRenderer graphics; 







    // Start is called before the first frame update
    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        //le serpent se depalce
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); // normaliser set a mettre la taille du vecteur a 1 


        //si l'ennemi est presque arrive a la destination 
        if(Vector3.Distance (transform.position, target.position) < 0.3f)
        {
            //Permet de dire d'aller au point suivant 
            destPoint = (destPoint + 1) % wayPoints.Length;
            target = wayPoints[destPoint];

            //permet de faire retoruner l'image du serpent, dans Unity on active par default flip X sinon sa flip mal
            graphics.flipX = !graphics.flipX; 
        }





    }
}
