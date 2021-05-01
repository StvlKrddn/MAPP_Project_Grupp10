using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float spriteLength, startPosition;
    public GameObject camera;
    public float parallaxAmount;

    void Awake()
    {
        startPosition = transform.position.x;
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        // Calculate the distance the layer should move relative to the camera
        float distance = camera.transform.position.x * parallaxAmount;

        // Apply the movement to the layer's position
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);

        // Move the layer if the camera goes past the sprites length
        float temp = camera.transform.position.x * (1- parallaxAmount);
        if (temp > startPosition + spriteLength)
            startPosition += spriteLength;
        else if (temp < startPosition - spriteLength)
            startPosition -= spriteLength;
    }
}
