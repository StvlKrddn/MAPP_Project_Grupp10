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
        print("blir man kollidad");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerState>().damagePlayer(damage);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.GetComponent<PlayerState>().invinciblePlayer();
            audioSource.PlayOneShot(playerDamageClip);
        }
    }

}
