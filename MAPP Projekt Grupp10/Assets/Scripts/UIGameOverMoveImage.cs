using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverMoveImage : MonoBehaviour
{

    private Vector2 startPos;
    [SerializeField] private float speed = 1;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }

    private void Update()
    {

        

        if (gameObject.transform.localPosition.x < -1080)
        {
            gameObject.transform.position = startPos;
        }

        transform.Translate(Vector2.left * Time.deltaTime * speed);


     

    }



}
