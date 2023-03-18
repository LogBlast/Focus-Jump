using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCamera : MonoBehaviour
{
    public Transform player;
    public List<Transform> cameras;
    private float cameraHeight=10f;

    public Transform activeCamera;
    private int cameraIndex=0;
    //ouahdipuhapziûedhapiuzdpioauzd

    void Start()
    {
        // Set the first camera as active
        activeCamera = cameras[cameraIndex];
        activeCamera.gameObject.SetActive(true);
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
            cameraHeight += 14f;
        }
        else if (player.position.y < cameraHeight - 14f && cameraIndex > 0)
        {
            // Disable the current camera and activate the previous one
            activeCamera.gameObject.SetActive(false);
            cameraIndex--;
            activeCamera = cameras[cameraIndex];
            activeCamera.gameObject.SetActive(true);

            // Decrease the camera height threshold
            cameraHeight -= 14;
        }
    }
}
