using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCamera : MonoBehaviour
{
    public Transform player;
    public GameObject Maincamera;
    public float cameraHeight; 


    private void Start()
    {
        cameraHeight = 10f;//mettre le f
    }

    void Update()
    {
        // Check if the player has moved up or down enough to switch cameras
        if (player.position.y >= cameraHeight)
        {
            // Move the camera up by 14 units in Y
            Vector3 cameraPos = Maincamera.transform.position;
            cameraPos.y += 14f;//mettre le f
            Maincamera.transform.position = cameraPos;

            // Increase the camera height threshold
            cameraHeight += 14f;//mettre le f
        }
        else if (player.position.y < cameraHeight - 14f )//mettre le f
        {
            // Move the camera down by 14 units in Y
            Vector3 cameraPos = Maincamera.transform.position;
            cameraPos.y -= 14f;//mettre le f
            Maincamera.transform.position = cameraPos;

            // Decrease the camera height threshold
            cameraHeight -= 14f;//mettre le f
        }

    }

}
