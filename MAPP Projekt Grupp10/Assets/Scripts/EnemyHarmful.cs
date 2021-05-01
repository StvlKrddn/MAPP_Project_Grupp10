using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmful : MonoBehaviour
{

    [SerializeField] private int damage = 1;
    [SerializeField] private AudioClip playerDamageClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerState>().damagePlayer(damage);
            gameObject.GetComponent<Collider2D>().enabled = false;
            audioSource.PlayOneShot(playerDamageClip);
        }
    }

}
