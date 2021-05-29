using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Movement : MonoBehaviour
{
    [SerializeField] public float baseMovement;
    [SerializeField] public float fallSpeed;
    private float yChange;
    private float xChange;
    private RaycastHit2D downRay;
    private int layerMask = (1 << 9);

    public bool grounded = false;
    private bool isJumping = false;

    [SerializeField] float jumpStrength;
    [SerializeField] float deceleration;


    [SerializeField] private int slideTimer;
    private int startSlideTimer;
    private bool isSliding = false;

    private Animator playerAnimator;
    private PlayerState playerState;


    // Start is called before the first frame update
    void Start()
    {
        startSlideTimer = slideTimer;
        playerAnimator = GetComponent<Animator>();
        playerState = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space) && !isSliding)
        {
            Jump();
            // print("händer denna funktion");
        }
       
        /* if (grounded && Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
        {
            Slide();
            print("händer denna funktion");
        }*/

        if (grounded)
        {
            playerAnimator.SetBool("IsJumping", false);
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

            gameObject.transform.localScale = new Vector2(0.5f, 0.5f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;

            if (slideTimer <= 0)
            {
                isSliding = false;
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.7f);
                gameObject.transform.localScale = new Vector2(1, 1f);
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }

        }

        if (isJumping)
        {
            yChange -= deceleration;
            if (yChange < fallSpeed)
            {
                yChange = fallSpeed;
            }
        }
        else
        {
            yChange = fallSpeed;
        }



        if (downRay.distance < Mathf.Abs(yChange) && Mathf.Sign(yChange) == -1 && downRay.collider != null)
        {
            yChange = -downRay.distance;
            isJumping = false;
            grounded = true;


            //print(downRay.collider);

        }

        if(downRay.collider == null)
        {
            grounded = false;
        }
        //     print(downRay.distance + " distansen");
        //     print(yChange);
        if (playerState.isGameActive)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + baseMovement, gameObject.transform.position.y);
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + yChange);
        }
        
    }


    public void Jump()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
        playerAnimator.SetBool("IsJumping", true);
        isJumping = true;
        yChange = jumpStrength;
        grounded = false;
    }

    public void Slide()
    {
        isSliding = true;
        slideTimer = startSlideTimer;
    }
}

