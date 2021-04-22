using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Movement : MonoBehaviour
{
    [SerializeField] private float baseMovement;
    [SerializeField] private float fallSpeed;
    private float yChange;
    private float xChange;
    private RaycastHit2D downRay;
    private int layerMask = (1 << 9);

    private bool grounded = false;
    private bool isJumping = false;

    [SerializeField] float jumpStrength;
    [SerializeField] float deAcceleration;


    [SerializeField] private int slideTimer;
    private int startSlideTimer;
    private bool isSliding = false;


    // Start is called before the first frame update
    void Start()
    {
        startSlideTimer = slideTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space) && !isSliding)
        {
            Jump();
            // print("händer denna funktion");
        }
        if (grounded && Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
            Slide();
            print("händer denna funktion");
        }

    }


    private void FixedUpdate()
    {
        downRay = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - gameObject.transform.localScale.y / 2),
           Vector2.down, Mathf.Infinity, layerMask);

        // print(downRay.collider.GetComponentInParent<Transform>().position.x);

        if (isSliding)
        {
            slideTimer -= 1;

            gameObject.transform.localScale = new Vector2(1, 1);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            if (slideTimer <= 0)
            {
                isSliding = false;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f);
                gameObject.transform.localScale = new Vector2(1, 1.7f);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }

        }

        if (isJumping)
        {
            yChange -= deAcceleration;
            if (yChange < fallSpeed)
            {
                yChange = fallSpeed;
            }
        }
        else
        {
            yChange = fallSpeed;
        }



        if (downRay.distance < Mathf.Abs(yChange) && Mathf.Sign(yChange) == -1)
        {
            yChange = -downRay.distance;
            isJumping = false;
            grounded = true;

        }
        //     print(downRay.distance + " distansen");
        //     print(yChange);
        //
        print(isJumping);
        print(grounded + " Är man grounded");
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + baseMovement, gameObject.transform.position.y);

        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + yChange);
    }


    private void Jump()
    {
        isJumping = true;
        yChange = jumpStrength;
        grounded = false;
    }

    private void Slide()
    {
        isSliding = true;
        slideTimer = startSlideTimer;
    }
}

