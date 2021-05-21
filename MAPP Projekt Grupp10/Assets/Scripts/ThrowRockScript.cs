using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRockScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;
    public Rigidbody2D rb;

    private void FixedUpdate(){
        rb.velocity = Vector2.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Banana") || collision.gameObject.CompareTag("Heart")){

        } else {
            Destroy(gameObject);
        }
    }

}
