using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 7f;

    [SerializeField] GameObject target;

    private Rigidbody2D rb;

    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject collisionParticles;

    Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 6f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerState>().DamagePlayer(damage);
            Instantiate(collisionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
