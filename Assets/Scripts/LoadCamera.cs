using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCamera : MonoBehaviour
{
    public Transform player;
    public List<Transform> cameras;
    private float cameraHeight=10f; //mettre le f

    public Transform activeCamera ;
    public int cameraIndex;
    

    void Start()
    {

        // Set the first camera as active
        activeCamera = cameras[0];
        int index = cameras.IndexOf(activeCamera);
        cameraIndex = (index != -1) ? index : 0;
        activeCamera.gameObject.SetActive(true);
        Debug.Log(activeCamera);



    }

    void Update()
    {
        // Check if the player has moved up or down enough to switch cameras
        if (player.position.y >= cameraHeight && cameraIndex < cameras.Count - 1)
        {
            // Disable the current camera and activate the next one
            activeCamera.gameObject.SetActive(false);
            cameraIndex++;
            activeCamera = cameras[cameraIndex];
            activeCamera.gameObject.SetActive(true);

            // Increase the camera height threshold
            cameraHeight += 14f;//mettre le f
        }
        else if (player.position.y < cameraHeight - 14f && cameraIndex > 0)//mettre le f
        {
            // Disable the current camera and activate the previous one
            activeCamera.gameObject.SetActive(false);
            cameraIndex--;
            activeCamera = cameras[cameraIndex];
            activeCamera.gameObject.SetActive(true);

            // Decrease the camera height threshold
            cameraHeight -= 14f;//mettre le f
        }
        Debug.Log(activeCamera);
    }

}
