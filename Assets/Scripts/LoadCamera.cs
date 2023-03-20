using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCamera : MonoBehaviour
{
    public Transform player;
    public List<Transform> cameras;
    public float cameraHeight = 10f; //mettre le f

    public Transform activeCamera;
    public int cameraIndex;


    void Start()
    {

        // Set the first camera as active
        activeCamera = cameras[0];
        int index = cameras.IndexOf(activeCamera);
        cameraIndex = (index != -1) ? index : 0;

        // Activer la premi�re cam�ra
        activeCamera.GetComponent<Camera>().enabled = true;

        // D�boguer la cam�ra active
        Debug.Log(activeCamera);


    }

    void Update()
    {
        // Check if the player has moved up or down enough to switch cameras
        if (player.position.y >= cameraHeight && cameraIndex < cameras.Count - 1)
        {
            // D�sactiver la cam�ra courante et activer la suivante
            activeCamera.GetComponent<Camera>().enabled = false;
            cameraIndex++;
            activeCamera = cameras[cameraIndex];

            // Activer la nouvelle cam�ra
            activeCamera.GetComponent<Camera>().enabled = true;

            // Augmenter le seuil de hauteur de la cam�ra
            cameraHeight += 14f;
        }
        else if (player.position.y < cameraHeight - 14f && cameraIndex > 0)
        {
            // D�sactiver la cam�ra courante et activer la pr�c�dente
            activeCamera.GetComponent<Camera>().enabled = false;
            cameraIndex--;
            activeCamera = cameras[cameraIndex];

            // Activer la nouvelle cam�ra
            activeCamera.GetComponent<Camera>().enabled = true;

            // Diminuer le seuil de hauteur de la cam�ra
            cameraHeight -= 14f;
        }

        // D�boguer la cam�ra active
        Debug.Log(activeCamera);

    }
}
