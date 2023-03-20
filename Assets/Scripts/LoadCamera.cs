using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCamera : MonoBehaviour
{
    public Transform player;
    public GameObject mainCamera;
    public float cameraHeight = 14f;
    public float cameraStep = 14f;

    private float lastCameraHeight;

    void Start()
    {
        lastCameraHeight = cameraHeight;
    }

    void Update()
    {
        if (player.position.y >= lastCameraHeight + cameraStep)
        {
            // Move the camera up by cameraStep units
            mainCamera.transform.position += Vector3.up * cameraStep;

            // Increase the camera height threshold
            lastCameraHeight += cameraStep;
        }
        else if (player.position.y < lastCameraHeight)
        {
            // Move the camera down by cameraStep units
            mainCamera.transform.position -= Vector3.up * cameraStep;

            // Decrease the camera height threshold
            lastCameraHeight -= cameraStep;
        }
    }


}

