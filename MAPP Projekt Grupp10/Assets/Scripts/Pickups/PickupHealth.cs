using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    private bool canPickUpHealth = true;
    [SerializeField] private int amountHealed = 1;

    [SerializeField] private AudioClip playerHealedClip;
    [SerializeField] private ParticleSystem healthParticles;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true && canPickUpHealth == true && collision.GetComponent<PlayerState>().GetCurrentHealth() < collision.GetComponent<PlayerState>().GetMaxHealth())
        {
            collision.GetComponent<PlayerState>().HealPlayer(amountHealed);
            canPickUpHealth = false;
            Instantiate(healthParticles, transform.position, healthParticles.transform.rotation);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<AudioManager>().Play("PickupHealth");
        }
    }

}
