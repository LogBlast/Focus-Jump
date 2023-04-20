using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBarManage : MonoBehaviour
{
    public GameObject joueur;
    public GameObject jumpBar;
    public Vector3 posJoueur;

    public void FixedUpdate()
    {

        Debug.Log("Joueur"+joueur.transform.position);
        Debug.Log("Jumpbar"+jumpBar.GetComponent<RectTransform>().anchoredPosition);

        jumpBar.GetComponent<RectTransform>().anchoredPosition = joueur.transform.position;
    }


}
