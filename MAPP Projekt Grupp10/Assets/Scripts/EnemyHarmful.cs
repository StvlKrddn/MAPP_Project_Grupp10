using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmful : MonoBehaviour
{

    [SerializeField] private int damage = 1;
    [SerializeField] private AudioClip playerDamageClip;
    private bool hasDamagedPlayer = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasDamagedPlayer ==false)
        {
            collision.gameObject.GetComponent<PlayerState>().damagePlayer(damage);
            hasDamagedPlayer = true;
            collision.GetComponent<PlayerState>().invinciblePlayer();
            audioSource.PlayOneShot(playerDamageClip);
        }
        if(collision.gameObject.CompareTag("Rock")){
            Destroy(gameObject);
        }

    }

}
