using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectsOutOfBounds : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;

    private void Start()
    {
    }
    private void Update()
    {
        
        transform.position = (Vector2)playerGameObject.transform.position - new Vector2(50, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
