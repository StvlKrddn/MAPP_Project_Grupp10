using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBanana : MonoBehaviour
{
    private bool canPickUpBanana = true;

    [SerializeField] private AudioClip playerBananaPickupClip;
    private AudioSource audioSource;
    [SerializeField] private ParticleSystem bananaParticles;

    [SerializeField] private int bananaAmount = 1;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true && canPickUpBanana == true)
        {
            collision.GetComponent<PlayerState>().PickupBanana(bananaAmount);
            canPickUpBanana = false;
            Instantiate(bananaParticles, transform.position, bananaParticles.transform.rotation);
            GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<AudioManager>().Play("PickupBanana");
        }
    }


}
