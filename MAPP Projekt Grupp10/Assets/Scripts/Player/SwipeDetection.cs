using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public float yPixelDistanceToDetect = 20;
    public float xPixelDistanceToDetect = 20;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isMousePressed;

    private Scr_Movement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Scr_Movement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isMousePressed)
        {
            startPos = Input.mousePosition;
            isMousePressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && isMousePressed)
        {
            endPos = Input.mousePosition;
            if (startPos.y < endPos.y - yPixelDistanceToDetect && playerMovement.grounded)
            {
                Debug.Log("Swipe up");
                playerMovement.Jump();
            }
            /*else if (startPos.y > endPos.y + pixelDistanceToDetect && playerMovement.grounded)
            {
                Debug.Log("Swipe down");
                playerMovement.Slide();
            }*/
            else if (startPos.x < endPos.x - xPixelDistanceToDetect)
            {
                Debug.Log("Swipe right");
                playerMovement.GetComponent<PlayerShoot>().Shoot();
            }

            isMousePressed = false;
        }


    }

}
